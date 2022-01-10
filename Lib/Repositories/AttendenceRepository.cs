using Lib.Data;
using Lib.Entity;
using Lib.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Lib.Repositories
{
    public interface IAttendenceRepository : IRepository<Attendence>
    {
        public List<AttendenceModel> GetAttendenceByLessionId(int lessionId);
    }
    public class AttendenceRepository : RepositoryBase<Attendence>, IAttendenceRepository
    {
        public AttendenceRepository(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        public List<AttendenceModel> GetAttendenceByLessionId(int lessionId)
        {
            var query = from a in _dbcontext.Attendences
                        join l in _dbcontext.Lessions on a.LessionId equals l.LessionId
                        join e in _dbcontext.Enrollments on a.EnrollmentId equals e.EnrollmentId
                        join s in _dbcontext.Students on e.StudentId equals s.StudentId
                        where a.LessionId == lessionId
                        select new AttendenceModel
                        {
                            LessionId = a.LessionId,
                            ClassId = l.ClassId,
                            StudentId = e.StudentId,
                            StudentName = s.Name,
                            Status = a.Status
                        };
            return query.ToList();
        }
    }
}
