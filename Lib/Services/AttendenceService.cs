using Lib.Models;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Services
{
    public class AttendenceService
    {
        IAttendenceRepository attendenceRepository;
        ApplicationDbContext dbContext;

        public AttendenceService(IAttendenceRepository attendenceRepository, ApplicationDbContext dbContext)
        {
            this.attendenceRepository = attendenceRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public List<AttendenceModel> GetAttendenceByLessionId(int lessionId)
        {
            return attendenceRepository.GetAttendenceByLessionId(lessionId);
        }
    }
}
