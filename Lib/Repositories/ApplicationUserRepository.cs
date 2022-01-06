using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Lib.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        List<ApplicationUser> GetApplicationUserList();
        ApplicationUser GetApplicationUserById(string Id);

        public ApplicationUser Login(string Username, string Password);
    }
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public ApplicationUser GetApplicationUserById(string Id)
        {
            var query = _dbcontext.ApplicationUsers.SingleOrDefault(t => t.UserId.ToString() == Id);
            return query;
        }

        public List<ApplicationUser> GetApplicationUserList()
        {
            var query = _dbcontext.ApplicationUsers;
            return query.ToList();
        }

        public ApplicationUser Login(string Username,string Password)
        {
            return _dbcontext.ApplicationUsers
                .SingleOrDefault(c => c.Username == Username && 
                c.Password == Password);
        }
    }
}
