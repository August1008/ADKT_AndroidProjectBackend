using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lib.Services
{
    public class ClassService
    {
        IClassRepository classRepository;
        ApplicationDbContext dbContext;

        public ClassService(IClassRepository classRepository, ApplicationDbContext dbContext)
        {
            this.classRepository = classRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<Class> GetClassList()
        {
            return classRepository.GetClassList();
        }
        public Class GetClassById(string Id)
        {
            return classRepository.GetClassById(Id);
        }

        public string GenerateId()
        {
            string Id = Guid.NewGuid().ToString();
            Id = Id.Substring(0,6);
            return Id;
        }
        public void AddClass(Class newClass)
        {
            dbContext.Add(newClass);
            Save();
        }
        public void DeleteClass(string Id)
        {
            var oldClass = dbContext.Classes.SingleOrDefault(c => c.ClassId == Id);
            dbContext.Classes.Remove(oldClass);
            Save();   
        }
        public List<Class> GetClassByTeacherId(string Id)
        {
            return classRepository.GetClassByTeacherId(Id);
        }
    }
}
