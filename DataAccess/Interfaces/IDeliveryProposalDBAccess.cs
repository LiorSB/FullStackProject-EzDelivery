using EzD.Model;
using EzD_App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DataAccess.Interfaces
{
    public interface IDeliveryProposalDBAccess
    {
        // Add a delivery proposal to a package
        public bool AddDeliveryProposal(string userId, DeliveryProposal deliveryProposal,int packageId);
        // Get all delivery proposals sent for a certain package 
        public List<DeliveryProposal> GetDeliveryProposalsForPackage(int packageId);
        // Get all delivery proposals sent by the user
        public List<DeliveryProposal> GetDeliveryProposalsByUser(string userId);
        // Get a dictionary of all users by their DeliveryGuy ID.
        public Dictionary<int, User> GetAllUsersByDeliveryGuyId(List<DeliveryProposal> deliveryProposals);
        // Delete a DeliveryProposal by its ID
        public bool DeleteDeliveryProposal(int deliveryProposalId);
    }
}
