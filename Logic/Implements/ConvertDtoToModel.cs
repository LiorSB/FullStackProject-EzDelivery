using EzD.Model;
using EzD_App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.Logic.Implements
{
    public sealed class ConvertDtoToModel
    {
        public static Address ConvertAddressDtoToAddress(AddressDto addressDto)
        {
            return new()
            {
                City = addressDto.City,
                Street = addressDto.Street,
                HouseNum = addressDto.HouseNum
            };
        }

        public static Package ConvertPackageDtoToPackage(PackageDto packageDto)
        {
            return new()
            {
                SenderIsReceiver = packageDto.SenderIsReceiver,
                PackageID = packageDto.PackageID,
                SenderPhone = packageDto.SenderPhone,
                ContactPhone = packageDto.SenderIsReceiver ? packageDto.SenderPhone : packageDto.ContactPhone,
                Weight = packageDto.Weight,
                Description = packageDto.Description,
                PickUpDate = packageDto.PickUpDate,
                DeadLineDate = packageDto.DeadLineDate,
                FromAddress = ConvertAddressDtoToAddress(packageDto.FromAddress),
                ToAddress = ConvertAddressDtoToAddress(packageDto.ToAddress),
                Price = packageDto.Price,
                Status = (EzD.Model.Status)packageDto.Status
            };
        }

        public static User ConvertUserToUserDto(UserDto userDto)
        {
            return new()
            {
                UserID = userDto.UserID,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Credits = userDto.Credits,
                IdentityUser = userDto.IdentityUser,
            };
        }

        public static DeliveryGuy ConvertDeliveryGuyDToToDeliveryGuy(DeliveryGuyDto deliveryGuyDto)
        {
            return new()
            {
                DeliveryGuyID = deliveryGuyDto.DeliveryGuyID,
                Rank = deliveryGuyDto.Rank,
                NumberOfVotes = deliveryGuyDto.NumberOfVotes,
                Active = deliveryGuyDto.Active,
                Credits = deliveryGuyDto.Credits
            };
        }

        public static DeliveryProposal ConvertDeliveryProposalDtoToDeliveryProposal(DeliveryProposalDto deliveryProposalDto)
        {
            return new()
            {
                ProposalID = deliveryProposalDto.ProposalID,
                Price = deliveryProposalDto.Price,
                Comment = deliveryProposalDto.Comment
            };
        }

        public static ApprovedDelivery ConvertApprovedDeliveryDtoToApprovedDelivery(ApprovedDeliveryDto approvedDeliveryDto)
        {
            return new()
            {
                DeliveryID = approvedDeliveryDto.DeliveryID,
                Price = approvedDeliveryDto.Price,
                RankScore = approvedDeliveryDto.RankScore
            };
        }
    }
}
