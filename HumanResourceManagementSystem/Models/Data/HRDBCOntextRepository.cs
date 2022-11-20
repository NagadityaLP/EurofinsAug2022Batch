using HumanResourceManagementSystem.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HumanResourceManagementSystem.Models.Data
{
    public class HRDBCOntextRepository : IHRDBRepository
    {
        private HRDbContext db = new HRDbContext();
        public void Delete(int id)
        {
            PersonalInformation p = db.PersonalInfo.Find(id);
            db.PersonalInfo.Remove(p);
            db.SaveChanges();
        }

        public void Update(PersonalInformation p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.Entry(p.Address).State = System.Data.Entity.EntityState.Modified;
            db.Entry(p.Education).State = System.Data.Entity.EntityState.Modified;
            db.Entry(p.CivilInfo).State = System.Data.Entity.EntityState.Modified;
            db.Entry(p.OfficialInfo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public PersonalInformation GetPersonalInfo(int id)
        {
            return db.PersonalInfo.Find(id);
        }
        public List<PersonalInformation> GetAll()
        {
            return db.PersonalInfo.ToList();
        }

        public void Save(PersonalInformation info)
        {
            db.PersonalInfo.Add(info);
            db.SaveChanges();
        }

        public List<PersonalInformation> SearchPersonalInfos(string searchInfo)
        {
            return (from p in db.PersonalInfo
                    where p.FirstName.ToLower().Contains(searchInfo.ToLower())  || p.LastName.ToLower().Contains(searchInfo.ToLower())
                    select p).ToList();
        }
    }
}