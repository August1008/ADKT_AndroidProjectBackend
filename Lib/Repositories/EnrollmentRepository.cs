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

    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        public List<Enrollment> GetEnrollmentList();
        public Enrollment GetErmById(int Id);
        public List<EnrollmentModel> GetEnrollmentBystudentId(string studentId);
        public List<EnrollmentModel> GetEnrollmentByClassId(string classId);
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
        public List<EnrollmentModel> GetEnrollmentBystudentId(string studentId)
        {
            var query = from e in _dbcontext.Enrollments
                        join c in _dbcontext.Classes on e.ClassId equals c.ClassId
                        join t in _dbcontext.Teachers on c.TeacherId equals t.TeacherId
                        where e.StudentId == studentId
                        select new EnrollmentModel
                        {
                            classId = c.ClassId,
                            subject = c.Subject,
                            teacherName = t.Name,
                            startDate = c.startDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                            endDate = c.endDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                        };
 
            return query.ToList();
        }

        public List<EnrollmentModel> GetEnrollmentByClassId(string classId)
        {
            var query = from e in _dbcontext.Enrollments
                        join c in _dbcontext.Classes on e.ClassId equals c.ClassId
                        join t in _dbcontext.Students on e.StudentId equals t.StudentId
                        where e.ClassId == classId
                        select new EnrollmentModel
                        {
                            classId = c.ClassId,
                            subject = c.Subject,
                            startDate = c.startDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                            endDate = c.endDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                            studentName = t.Name,
                            studentId = t.StudentId
                        };
            return query.ToList();
        }
    }

}
