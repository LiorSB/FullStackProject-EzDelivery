using EzD.Model;
using EzD_App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.Logic.Interfaces
{
    public interface IApprovedDeliveryManager
    {
        // Get all approved deliveries to user that thier status is 'InProgress'.
        public List<ApprovedDeliveryDto> GetApprovedDeliveries(string userId);
        // change a package status to 'InProgress' to make an ApprovedDelivery.
        public bool ApproveDeliveryProposal(DeliveryProposalDto approvedDeliveryProposalDto);
        // Add a rank to a delivery which will update the ApprovedDelivery's Rank,
        // DeliveryGuy's Rank and Number of people that voted for that DeliveryGuy.
        public bool AddDeliveryRank(int rank, int packageId);
        // Get all votes made by the user
        public List<ApprovedDeliveryDto> GetAllVotes(string userId);
    }
}
