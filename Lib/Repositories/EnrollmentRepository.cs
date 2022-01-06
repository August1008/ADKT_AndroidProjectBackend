using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Repositories
{

    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        public List<Enrollment> GetEnrollmentList();
        public Enrollment GetErmById(int Id);

    }

    public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public List<Enrollment> GetEnrollmentList()
        {
            var query = _dbcontext.Enrollments;
            return query.ToList();
        }

        public Enrollment GetErmById(int Id)
        {
            var query = _dbcontext.Enrollments.SingleOrDefault(e => e.EnrollmentId == Id);
            return query;
        }
    }

}
