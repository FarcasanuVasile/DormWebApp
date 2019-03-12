using DormWebApp.Data.Infrastructure;
using DormWebApp.Domain.Entities;
using DormWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Services.Services
{
    public class UserServices : IUserServices
    {
        private DatabaseFactory databaseFactory;
        private Repository<Role> roleRepository;
        private Repository<User> userRepository;
        private IUnitOfWork unitOfWork;

        public UserServices(DatabaseFactory dbFactory)
        {
            this.databaseFactory = dbFactory;
            this.roleRepository = new Repository<Role>(databaseFactory);
            this.userRepository = new Repository<User>(databaseFactory);
            this.unitOfWork = new UnitOfWork(databaseFactory);
        }
        public void AddUser(User user)
        {
            user.Role = roleRepository.GetById(2);
            user.RoleId = 2;
            user.Role.Name = "User2";
            user.IsActive = true;
            user.RegisterOn = DateTime.Now;
            userRepository.Add(user);
            unitOfWork.Commit();
        }
        public void EditUser(User user)
        {
            userRepository.Update(user);
            unitOfWork.Commit();
        }
        public void DeleteUser(User user)
        {
            userRepository.Delete(user);
            unitOfWork.Commit();
        }
        public bool ExistingUsername(string userName)
        {
            var userCount = userRepository.GetAll().
                Count(u => u.Username.ToLower().Replace(" ", string.Empty)==userName.ToLower().Replace(" ",string.Empty));
            return userCount > 0;
        }
        public User GetUserByEmail (string email)
        {
            var user = userRepository.GetAll().Where(x => x.Email == email).FirstOrDefault();
            return user;
        }
        public bool ExistingEmailAddress(string email)
        {
            return userRepository.GetAll().Count(e => e.Email.ToLower().Replace(" ", string.Empty) == email.ToLower().Replace(" ", string.Empty)) > 0;
        }
    }
}
