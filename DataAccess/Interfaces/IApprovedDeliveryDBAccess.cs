using EzD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DataAccess.Interfaces
{
    public interface IApprovedDeliveryDBAccess
    {
        // Get all approved deliveries to user that thier status is 'InProgress'.
        public List<ApprovedDelivery> GetApprovedDeliveries(string userId);
        // change a package status to 'InProgress' to make an ApprovedDelivery.
        public bool ApproveDeliveryProposal(ApprovedDelivery approvedDelivery);
        // Add a rank to a delivery which will update the ApprovedDelivery's Rank,
        // DeliveryGuy's Rank and Number of people that voted for that DeliveryGuy.
        public bool AddDeliveryRank(int rank, int packageId);
        // Get all votes made by the user
        public List<ApprovedDelivery> GetAllVotes(string userId);       
    }
}
