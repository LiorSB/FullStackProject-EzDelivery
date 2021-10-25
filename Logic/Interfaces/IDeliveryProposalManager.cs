using EzD_App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.Logic.Interfaces
{
    public interface IDeliveryProposalManager
    {
        // Add a delivery proposal to a package
        public bool AddDeliveryProposal(string userId, DeliveryProposalDto deliveryProposalDto);
        // Get all delivery proposals sent by the user
        public List<DeliveryProposalDto> GetDeliveryProposalsByUser(string deliveryGuyId);
        // Delete a DeliveryProposal by its ID
        public bool DeleteDeliveryProposal(int deliveryProposalId);
        // Get all DeliveryProposal for a package
        public List<DeliveryProposalDto> GetDeliveryProposalsForPackage(int packageId);
    }
}
