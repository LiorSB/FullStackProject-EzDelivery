using EzD.Model;
using EzD_App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.Logic.Implements
{
    public sealed class ConvertModelToDto
    {
        public static AddressDto ConvertAddressToAddressDto(Address address)
        {
            return new()
            {
                City = address.City,
                Street = address.Street,
                HouseNum = address.HouseNum
            };
        }

        public static PackageDto ConvertPackageToPackageDto(Package package)
        {
            return new()
            {
                PackageID = package.PackageID,
                SenderPhone = package.SenderPhone,
                ContactPhone = package.ContactPhone,
                SenderIsReceiver = package.SenderIsReceiver,
                Weight = package.Weight,
                Description = package.Description,
                PickUpDate = package.PickUpDate,
                DeadLineDate = package.DeadLineDate,
                FromAddress = ConvertAddressToAddressDto(package.FromAddress),
                ToAddress = ConvertAddressToAddressDto(package.ToAddress),
                Price = package.Price,
                Status = (DTO.Status)package.Status
            };
        }    

        public static UserDto ConvertUserToUserDto(User user)
        {
            return new()
            {
                UserID = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Credits = user.Credits,
                IdentityUser = user.IdentityUser,
            };
        }

        public static DeliveryGuyDto ConvertDeliveryGuyToDeliveryGuyDto(DeliveryGuy deliveryGuy)
        {
            return new()
            {
                DeliveryGuyID = deliveryGuy.DeliveryGuyID,
                Rank = deliveryGuy.Rank,
                NumberOfVotes = deliveryGuy.NumberOfVotes,
                Active = deliveryGuy.Active,
                Credits = deliveryGuy.Credits
            };
        }
        
        public static DeliveryProposalDto ConvertDeliveryProposalToDeliveryProposalDto(DeliveryProposal deliveryProposal)
        {
            return new()
            {
                ProposalID = deliveryProposal.ProposalID,
                Price = deliveryProposal.Price,
                Comment = deliveryProposal.Comment
            };
        }

        public static ApprovedDeliveryDto ConvertApprovedDeliveryToApprovedDeliveryDto(ApprovedDelivery approvedDelivery)
        {
            return new()
            {
                DeliveryID = approvedDelivery.DeliveryID,
                Price = approvedDelivery.Price,
                RankScore = approvedDelivery.RankScore
            };
        }
    }
}
