using EzD.Model;
using EzD_App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EzD_App.Logic.Implements
{
    public sealed class DataValidation
    {
        public static bool IsPackageValid(PackageDto packageDto)
        {
            return (
            IsPhoneNumberValid(packageDto.SenderPhone) &&
            IsContactPhoneNumberValid(packageDto.ContactPhone, packageDto.SenderIsReceiver) &&
            IsPriceValid(packageDto.Weight.ToString()) &&
            IsDateValid(packageDto.PickUpDate, packageDto.DeadLineDate) &&
            IsAddressValid(packageDto.ToAddress) &&
            IsAddressValid(packageDto.FromAddress) &&
            IsDescriptionValid(packageDto.Description) &&
            IsPriceValid(packageDto.Price.ToString()));
        }

        public static bool IsContactPhoneNumberValid(string contactPhone, bool senderIsReceiver)
        {
            return senderIsReceiver || IsPhoneNumberValid(contactPhone);
        }

        public static bool IsPhoneNumberValid(string phoneNumber)
        {

            return Regex.Match(phoneNumber, @"^([0][0-9]{9})$").Success;
        }

        public static bool IsDateValid(DateTime pickUpDate, DateTime deadLineDate)
        {
            return pickUpDate <= deadLineDate;
        }
        public static bool IsPriceValid(string price)
        {
            return Regex.Match(price, @"^[0-9]{1,5}([.,][0-9]{1,3})?$").Success;
        }

        public static bool IsAddressValid(AddressDto addressDto)
        {
            return Regex.Match(addressDto.City, @"^([a-z- A-Z]{1,20})$").Success &&
                   Regex.Match(addressDto.Street, @"^([a-z- A-Z]{1,20})$").Success &&
                   Regex.Match(addressDto.HouseNum.ToString(), @"^([0-9]{1,4})$").Success;
        }
        public static bool IsDescriptionValid(string description)
        {
            return Regex.Match(description, @"^([a-z-,.\/?! A-Z0-9]{1,100})$").Success;
        }

        public static bool IsNameValid(string name)
        {
            return Regex.IsMatch(name, "[a-zA-Z]+");
        }
    }
}