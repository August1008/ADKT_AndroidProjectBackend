using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Services
{
    public class TeacherService
    {
        private ITeacherRepository teacherRepository { set; get; }
        private ApplicationDbContext dbContext;

        public TeacherService(ITeacherRepository teacherRepository, ApplicationDbContext dbContext)
        {
            this.teacherRepository = teacherRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public Teacher GetTeacherById(string Id)
        {
            return teacherRepository.GetTeacherById(Id);
        }

        public List<Teacher> GetTeacherList()
        {
            return teacherRepository.GetTeacherList();
        }
        public void AddTeacher(Teacher teacher)
        {
            dbContext.Add(teacher);
            Save();
        }
        public Teacher GetTeacherByUserId(Guid Id)
        {
            return teacherRepository.GetTeacherByUserId(Id);
        }
    }
}
