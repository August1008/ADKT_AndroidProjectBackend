using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Services
{
    public class StudentService
    {
        private IStudentRepository studentRepository { set; get; }
        private ApplicationDbContext dbContext;

        public StudentService(IStudentRepository studentRepository, ApplicationDbContext dbContext)
        {
            this.studentRepository = studentRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<Student> GetStudentList()
        {
            return studentRepository.GetStudentList();
        }

        public Student GetStudentById(string Id)
        {
            return studentRepository.GetStudentById(Id);
        }
        public Student GetStudentByPersonId(Guid personId)
        {
            return studentRepository.GetStudentByPersonId(personId);
        }
        public void AddStudent(Student student)
        {
            dbContext.Add(student);
            Save();
        }
        public Student GetStudentByUserId(Guid Id)
        {
            return studentRepository.GetStudentByUserId(Id);
        }
    }
}
