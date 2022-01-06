using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
        List<Class> GetClassList();
        Class GetClassById(string Id);
        List<Class> GetClassByTeacherId(string Id);


    }
    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(ApplicationDbContext dbContext):base(dbContext)
        {

        }
        public Class GetClassById(string Id)
        {
            var query = _dbcontext.Classes.SingleOrDefault(c => c.ClassId == Id);
            return query;
        }

        public List<Class> GetClassList()
        {
            var query = _dbcontext.Classes;
            return query.ToList();
        }

        public List<Class> GetClassByTeacherId(string Id)
        {
            var query = _dbcontext.Classes.Where(c => c.TeacherId == Id);
            return query.ToList();
        }
    }
}
