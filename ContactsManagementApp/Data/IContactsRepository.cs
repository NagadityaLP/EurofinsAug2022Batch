using ContactsManagementApp.Entities;
using System.Collections.Generic;

namespace ContactsManagementApp.Data
{
    public interface IContactsRepository
    {
        void Save(Contact contact);
        List<Contact> GetContacts();
        Contact GetContactById(int id);

        List<Contact> GetContactsByLocation(string location);

        void Delete(int id);
        void Edit(int id, Contact modifiedContact);
    }
}
