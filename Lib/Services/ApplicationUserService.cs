using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Services
{
    public class ApplicationUserService
    {
        private IApplicationUserRepository userRepository { set; get; }
        private ApplicationDbContext dbContext;

        public ApplicationUserService(IApplicationUserRepository teacherRepository, ApplicationDbContext dbContext)
        {
            this.userRepository = teacherRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public ApplicationUser GetApplicationUserById(string Id)
        {
            return userRepository.GetApplicationUserById(Id);
        }

        public List<ApplicationUser> GetApplicationUserList()
        {
            return userRepository.GetApplicationUserList();
        }
        public void AddUser(ApplicationUser user)
        {
            dbContext.ApplicationUsers.Add(user);
            Save();
        }

        public ApplicationUser Login(string Username,string Password)
        {
            return userRepository.Login(Username, Password);
        }
        public void DeleteUser(string Id)
        {
            ApplicationUser user = dbContext.ApplicationUsers.Find(new Guid(Id));
            dbContext.ApplicationUsers.Remove(user);
            Save();
        }
    }
}
