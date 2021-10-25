using EzD.Model;
using EzD_App.Data;
using EzD_App.DataAccess.Interfaces;
using EzD_App.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DataAccess.Impliments
{
    public class UserDBAccess : IUserDBAccess
    {
        readonly ApplicationDbContext _dbContext;

        public UserDBAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddIdentityUser(User user)
        {
            _dbContext.User.Add(user);
            return SaveDbChanges();
        }

        public bool UpdateUserName(User user, string userId)
        {
            User userDb = GetUser(userId);

            if (userDb == null)
            {
                return false;
            }

            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;

            return SaveDbChanges();
        }

        public User GetUser(string userId)
        {
            return _dbContext.User.Include(u => u.IdentityUser).Include(u => u.DeliveryGuy)
                .SingleOrDefault(u => u.IdentityUser.Id.Equals(userId));
        }

        public bool CreateDeliveryGuy(string userId)
        {
            User userDb = GetUser(userId);

            if (userDb == null)
            {
                return false;
            }

            // Create a new delivery guy incase the user has never been one before.
            if (userDb.DeliveryGuy == null)
            {
                userDb.DeliveryGuy = new DeliveryGuy();
            }

            userDb.DeliveryGuy.Active = true;

            return SaveDbChanges();
        }

        public bool SetDeliveryGuyInactive(string userId)
        {
            User userDb = GetUser(userId);

            if (userDb == null || userDb.DeliveryGuy == null)
            {
                return false;
            }

            userDb.DeliveryGuy.Active = false;

            return SaveDbChanges();
        }

        public DeliveryGuy GetDeliveryGuy(string userId)
        {
            User userDb = GetUser(userId);

            if (userDb == null)
            {
                return null;
            }

            return userDb.DeliveryGuy;
        }

        public bool IsDeliveryGuyActive(string userId)
        {
            User userDb = GetUser(userId);

            if (userDb == null)
            {
                return false;
            }

            return userDb.DeliveryGuy != null && userDb.DeliveryGuy.Active;
        }

        public string GetEmail(string userId)
        {
            User userDb = GetUser(userId);

            if (userDb == null)
            {
                return null;
            }

            return userDb.IdentityUser.Email;
        }

        private bool SaveDbChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
