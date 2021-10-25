using EzD.Model;
using EzD_App.DataAccess.Interfaces;
using EzD_App.DTO;
using EzD_App.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.Logic.Implements
{
    public class DeliveryProposalManager : IDeliveryProposalManager
    {
        readonly IDeliveryProposalDBAccess _deliveryProposalDBAccess;
        public DeliveryProposalManager(IDeliveryProposalDBAccess deliveryProposalDBAccess)
        {
            _deliveryProposalDBAccess = deliveryProposalDBAccess;
        }

        public bool AddDeliveryProposal(string userId, DeliveryProposalDto deliveryProposalDto)
        {
            DeliveryProposal deliveryProposal = 
                ConvertDtoToModel.ConvertDeliveryProposalDtoToDeliveryProposal(deliveryProposalDto);

            return _deliveryProposalDBAccess.AddDeliveryProposal
                (userId, deliveryProposal, deliveryProposalDto.Package.PackageID);
        }

        public List<DeliveryProposalDto> GetDeliveryProposalsByUser(string deliveryGuyId)
        {
            List<DeliveryProposal> deliveryProposals = _deliveryProposalDBAccess
                .GetDeliveryProposalsByUser(deliveryGuyId);

            List<DeliveryProposalDto> deliveryProposalsDto = new();
            DeliveryProposalDto deliveryProposalDto;

            foreach (DeliveryProposal deliveryProposal in deliveryProposals)
            {
                deliveryProposalDto = ConvertModelToDto
                    .ConvertDeliveryProposalToDeliveryProposalDto(deliveryProposal);
                deliveryProposalDto.Package = ConvertModelToDto
                    .ConvertPackageToPackageDto(deliveryProposal.Package);
                deliveryProposalDto.IntrestedDeliveryGuy = ConvertModelToDto
                    .ConvertDeliveryGuyToDeliveryGuyDto(deliveryProposal.IntrestedDeliveryGuy);

                deliveryProposalsDto.Add(deliveryProposalDto);
            }

            return deliveryProposalsDto;
        }

        public bool DeleteDeliveryProposal(int deliveryProposalId)
        {
            return _deliveryProposalDBAccess.DeleteDeliveryProposal(deliveryProposalId);
        }

        public List<DeliveryProposalDto> GetDeliveryProposalsForPackage(int packageId)
        {
            List<DeliveryProposal> deliveryProposals = 
                _deliveryProposalDBAccess.GetDeliveryProposalsForPackage(packageId);
            Dictionary<int, User> userDictionary = 
                _deliveryProposalDBAccess.GetAllUsersByDeliveryGuyId(deliveryProposals);

            List<DeliveryProposalDto> deliveryProposalDtoList = new();
            DeliveryProposalDto deliveryProposalDto;

            foreach (DeliveryProposal deliveryProposal in deliveryProposals)
            {
                // Convert DeliveryProposal and inner objects: Package and DeliveryGuy
                deliveryProposalDto = ConvertModelToDto
                    .ConvertDeliveryProposalToDeliveryProposalDto(deliveryProposal);
                deliveryProposalDto.Package = ConvertModelToDto
                    .ConvertPackageToPackageDto(deliveryProposal.Package);
                deliveryProposalDto.IntrestedDeliveryGuy = ConvertModelToDto
                    .ConvertDeliveryGuyToDeliveryGuyDto(deliveryProposal.IntrestedDeliveryGuy);

                // Get first and last name and phone number from dictionary
                deliveryProposalDto.FirstName = 
                    userDictionary[deliveryProposal.IntrestedDeliveryGuy.DeliveryGuyID].FirstName;
                deliveryProposalDto.LastName = 
                    userDictionary[deliveryProposal.IntrestedDeliveryGuy.DeliveryGuyID].LastName;
                deliveryProposalDto.PhoneNumber = 
                    userDictionary[deliveryProposal.IntrestedDeliveryGuy.DeliveryGuyID].IdentityUser.PhoneNumber;

                deliveryProposalDtoList.Add(deliveryProposalDto);
            }

            return deliveryProposalDtoList;
        }
    }
}