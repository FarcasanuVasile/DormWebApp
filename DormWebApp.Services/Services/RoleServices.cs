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
    public class RoleServices : IRoleServices
    {
        private DatabaseFactory dbFactory ;
        private IUnitOfWork unitOfWork;
        private Repository<Role> roleRepository;

        public RoleServices( DatabaseFactory databaseFactory)
        {
            this.dbFactory = databaseFactory;
            this.unitOfWork = new UnitOfWork(dbFactory);
            this.roleRepository = new Repository<Role>(dbFactory);
        }

        public bool AddRole(Role role)
        {
            var result = false;
            var existingRole = ExistingRole(role.Name);
            if (!existingRole)
            {
                roleRepository.Add(role);
                unitOfWork.Commit();
                result = true;
            }
            return result;
        }

        public void EditRole(Role role)
        {

        }

        public void DeleteRole(Role role)
        {

        }

        public bool ExistingRole(string roleName)
        {
            return roleRepository.GetAll().Count(x => x.Name.ToLower().Replace(" ", string.Empty) == roleName.ToLower().Replace(" ", string.Empty)) > 0;
        }

        

    }
}
