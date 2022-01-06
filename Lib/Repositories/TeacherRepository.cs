using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Lib.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        List<Teacher> GetTeacherList();
        Teacher GetTeacherById(string Id);
        Teacher GetTeacherByUserId(Guid Id);
    }
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public Teacher GetTeacherById(string Id)
        {
            var query = _dbcontext.Teachers.SingleOrDefault(t => t.TeacherId == Id);
            return query;
        }

        public List<Teacher> GetTeacherList()
        {
            var query = _dbcontext.Teachers;
            return query.ToList();
        }
        public Teacher GetTeacherByUserId(Guid Id)
        {
            var query = _dbcontext.Teachers.SingleOrDefault(t => t.UserId == Id);
            return query;
        }
    }
}
