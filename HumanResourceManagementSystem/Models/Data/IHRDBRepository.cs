using HumanResourceManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourceManagementSystem.Models.Data
{
    public interface IHRDBRepository
    {
        void Save(PersonalInformation info);
        void Delete(int id);
        void Update(PersonalInformation info);
        PersonalInformation GetPersonalInfo(int id);
        List<PersonalInformation> GetAll();
        List<PersonalInformation> SearchPersonalInfos(string searchInfo);
    }
    
}
