using System;
using System.Collections.Generic;
using System.Text;
using Lib.Data;
using Lib.Entity;
using Lib.Repositories;
namespace Lib.Services
{
    public class LessionService
    {
        private ILessionRepository lessionRepository;
        private ApplicationDbContext dbContext;

        public LessionService(ILessionRepository lessionRepository, ApplicationDbContext dbContext)
        {
            this.lessionRepository = lessionRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<Lession> GetLessionList()
        {
            return lessionRepository.GetLessionList();
        }
        public Lession GetLessionById(int Id)
        {
            return lessionRepository.GetLessionById(Id);
        }
        public void AddLession(Lession lession)
        {
            dbContext.Lessions.Add(lession);
            Save();
        }

        public string GenerateId()
        {
            string Id = Guid.NewGuid().ToString();
            Id = Id.Substring(0, 6);
            return Id;
        }

        public List<Lession> GetLessionByClassId(string classId)
        {
            return lessionRepository.GetLessionByClassId(classId);
        }
    }
}
