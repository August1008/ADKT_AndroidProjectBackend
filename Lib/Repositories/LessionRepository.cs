using System;
using System.Collections.Generic;
using System.Text;
using Lib.Data;
using Lib.Entity;
using System.Linq;
namespace Lib.Repositories
{
    public interface ILessionRepository:IRepository<Lession>
    {
        public List<Lession> GetLessionList();
        public Lession GetLessionById(int Id);

    }
    public class LessionRepository : RepositoryBase<Lession>, ILessionRepository
    {
        public LessionRepository(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        public Lession GetLessionById(int Id)
        {
            var query = _dbcontext.Lessions.SingleOrDefault(l => l.LessionId == Id);
            return query;
        }

        public List<Lession> GetLessionList()
        {
            var query = _dbcontext.Lessions;
            return query.ToList();
        }
    }
}
