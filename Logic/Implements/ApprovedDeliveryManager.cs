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
    public class ApprovedDeliveryManager : IApprovedDeliveryManager
    {
        readonly IApprovedDeliveryDBAccess _ApprovedDeliveryDBAccess;
        public ApprovedDeliveryManager(IApprovedDeliveryDBAccess approvedDeliveryDBAccess)
        {
            _ApprovedDeliveryDBAccess = approvedDeliveryDBAccess;
        }

        public List<ApprovedDeliveryDto> GetApprovedDeliveries(string userId)
        {
            List<ApprovedDelivery> approvedDeliveries = 
                _ApprovedDeliveryDBAccess.GetApprovedDeliveries(userId);

            List<ApprovedDeliveryDto> approvedDeliveriesDto = new();
            ApprovedDeliveryDto approvedDeliveryDto;

            foreach (ApprovedDelivery approvedDelivery in approvedDeliveries)
            {
                approvedDeliveryDto = 
                    ConvertModelToDto.ConvertApprovedDeliveryToApprovedDeliveryDto(approvedDelivery);
                approvedDeliveryDto.ChosenDeliveryGuy = 
                    ConvertModelToDto.ConvertDeliveryGuyToDeliveryGuyDto(approvedDelivery.ChosenDeliveryGuy);
                approvedDeliveryDto.Package = 
                    ConvertModelToDto.ConvertPackageToPackageDto(approvedDelivery.Package);
                approvedDeliveryDto.Package.Owner =
                    ConvertModelToDto.ConvertUserToUserDto(approvedDelivery.Package.Owner);

                approvedDeliveriesDto.Add(approvedDeliveryDto);
            }

            return approvedDeliveriesDto;
        }

        public bool ApproveDeliveryProposal(DeliveryProposalDto approvedDeliveryProposalDto)
        {
            ApprovedDelivery approvedDelivery = new()
            {
                ChosenDeliveryGuy =
                ConvertDtoToModel.ConvertDeliveryGuyDToToDeliveryGuy(approvedDeliveryProposalDto.IntrestedDeliveryGuy),
                Package =
                ConvertDtoToModel.ConvertPackageDtoToPackage(approvedDeliveryProposalDto.Package),
                Price = (float)approvedDeliveryProposalDto.Price
            };

            return _ApprovedDeliveryDBAccess.ApproveDeliveryProposal(approvedDelivery);
        }

        public bool AddDeliveryRank(int rank, int packageId)
        {
            return _ApprovedDeliveryDBAccess.AddDeliveryRank(rank, packageId);
        }

        public List<ApprovedDeliveryDto> GetAllVotes(string userId)
        {
            List<ApprovedDelivery> approvedDeliveries = _ApprovedDeliveryDBAccess.GetAllVotes(userId);
            List<ApprovedDeliveryDto> approvedDeliveriesDto = new();
            ApprovedDeliveryDto approvedDeliveryDto;

            foreach (ApprovedDelivery approvedDelivery in approvedDeliveries)
            {
                approvedDeliveryDto =
                    ConvertModelToDto.ConvertApprovedDeliveryToApprovedDeliveryDto(approvedDelivery);
                approvedDeliveryDto.ChosenDeliveryGuy =
                    ConvertModelToDto.ConvertDeliveryGuyToDeliveryGuyDto(approvedDelivery.ChosenDeliveryGuy);
                approvedDeliveryDto.Package =
                    ConvertModelToDto.ConvertPackageToPackageDto(approvedDelivery.Package);
                approvedDeliveryDto.Package.Owner =
                    ConvertModelToDto.ConvertUserToUserDto(approvedDelivery.Package.Owner);

                approvedDeliveriesDto.Add(approvedDeliveryDto);
            }

            return approvedDeliveriesDto; 
        }
    }
}
