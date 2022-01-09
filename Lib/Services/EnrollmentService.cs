using Lib.Entity;
using Lib.Models;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Services
{
    public class EnrollmentService
    {
        private IEnrollmentRepository enrollmentRepository { set; get; }
        private ApplicationDbContext dbContext { set; get; }

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, ApplicationDbContext dbContext)
        {
            this.enrollmentRepository = enrollmentRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public List<Enrollment> GetEnrollmentList()
        {
            return enrollmentRepository.GetEnrollmentList();
        }
        public Enrollment GetEnrollmentById(int Id)
        {
            return enrollmentRepository.GetErmById(Id);
        }
        public void AddEnrollment(Enrollment enrollment)
        {
            dbContext.Enrollments.Add(enrollment);
            Save();
        }
        public List<EnrollmentModel> GetEnrollmentsBystudentId(string studentId)
        {
            return enrollmentRepository.GetEnrollmentBystudentId(studentId);
        }
    }
}
