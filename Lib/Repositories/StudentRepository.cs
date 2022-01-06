using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetStudentList();
        Student GetStudentById(string Id);
        Student GetStudentByPersonId(Guid personId);

        Student GetStudentByUserId(Guid Id);

    }

    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public List<Student> GetStudentList()
        {
            var query = _dbcontext.Students;
            return query.ToList();
        }
        public Student GetStudentById(string Id)
        {
            var query = _dbcontext.Students.SingleOrDefault(st=>st.StudentId == Id);
            return query;
        }
        public Student GetStudentByPersonId(Guid personId)
        {
            var query = _dbcontext.Students.SingleOrDefault(st => st.PersonId == personId);
            return query;
        }
        public Student GetStudentByUserId(Guid Id)
        {
            var query = _dbcontext.Students.SingleOrDefault(st => st.UserId == Id);
            return query;
        }

    }
}
