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
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetStudentList();
        Student GetStudentById(string Id);
        StudentModel GetStudentByPersonId(Guid personId);

        Student GetStudentByUserId(Guid Id);

        void DeleteStudent(string Id);

        

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
        public StudentModel GetStudentByPersonId(Guid personId)
        {
            var query = _dbcontext.Students.SingleOrDefault(st => st.PersonId == personId);
            return new StudentModel
            {
                StudentId = query.StudentId,
                Email = query.Email,
                birthDay = query.birthDay.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                Name = query.Name,
                PersonId = query.PersonId
            };
        }
        public Student GetStudentByUserId(Guid Id)
        {
            var query = _dbcontext.Students.SingleOrDefault(st => st.UserId == Id);
            return query;
        }
        public void DeleteStudent(string Id)
        {
            var query = _dbcontext.Students.SingleOrDefault(st => st.StudentId == Id);
            _dbcontext.Students.Remove(query);
        }
        
    }
}
