using ContactsManagementApp.Entities;
using System.Collections.Generic;
using System.IO;

namespace ContactsManagementApp.Data
{
    public class ContactsFileRepository : IContactsRepository
    {
        private readonly string file = "C:\\contactslist2022.txt";

        private List<int> savedContactIDs = new List<int>();

        public ContactsFileRepository()
        {
            File.Delete("C:\\contactslist2022.txt");
        }
        public void Delete(int id)
        {
            List<Contact> contacts = new List<Contact>();
            StreamReader reader = new StreamReader(file);
            try
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Contact contact = new Contact();
                    string[] data = line.Split(',');
                    if (id == int.Parse(data[0]))
                        continue;
                    else
                    {
                        contact.ContactID = int.Parse(data[0]);
                        contact.Name = data[1];
                        contact.Mobile = data[2];
                        contact.Email = data[3];
                        contact.Location = data[4];
                        contacts.Add(contact);
                    }
                }
            }
            finally
            {
                reader.Close();
            }

            //delete the old file so that old contents will be erased
            File.Delete(file);
            foreach (Contact contact in contacts)
                Save(contact);
        }

        public void Edit(int id, Contact modifiedContact)
        {
            List<Contact> contacts = new List<Contact>();
            StreamReader reader = new StreamReader(file);
            try
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Contact contact = new Contact();
                    string[] data = line.Split(',');
                    if (id == int.Parse(data[0]))
                    {
                        contacts.Add(modifiedContact);
                    }
                    else
                    {
                        contact.ContactID = int.Parse(data[0]);
                        contact.Name = data[1];
                        contact.Mobile = data[2];
                        contact.Email = data[3];
                        contact.Location = data[4];
                        contacts.Add(contact);
                    }
                }
                
            }
            finally
            {
                reader.Close();
            }

            //delete the old file so that old contents will be erased
            File.Delete(file);
            //savedContactIDs.Clear();
            foreach (Contact contact in contacts)
                Save(contact);

        }

        public Contact GetContactById(int id)
        {
            StreamReader reader = new StreamReader(file);
            Contact contact = new Contact();
            try
            {
                while (!reader.EndOfStream)
                {
                    string contactLine = reader.ReadLine();
                    string[] data = contactLine.Split(',');
                    if (id == int.Parse(data[0]))
                    {
                        contact.ContactID = int.Parse(data[0]);
                        contact.Name = data[1];
                        contact.Mobile = data[2];
                        contact.Email = data[3];
                        contact.Location = data[4];
                        break;
                    }
                }
            }
            finally
            {
                reader.Close();
            }
            return contact;
        }

        public List<Contact> GetContacts()
        {
            StreamReader reader = new StreamReader(file);
            List<Contact> contacts = new List<Contact>();
            try
            {
                while (!reader.EndOfStream)
                {
                    string contactLine = reader.ReadLine();
                    Contact contact = new Contact();
                    string[] data = contactLine.Split(',');
                    contact.ContactID = int.Parse(data[0]);
                    contact.Name = data[1];
                    contact.Mobile = data[2];
                    contact.Email = data[3];
                    contact.Location = data[4];
                    contacts.Add(contact);
                }
            }
            finally
            {
                reader.Close();
            }
            return contacts;
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            StreamReader reader = new StreamReader(file);
            List<Contact> contacts = new List<Contact>();
            try
            {
                while (!reader.EndOfStream)
                {
                    string contactLine = reader.ReadLine();
                    string[] data = contactLine.Split(',');
                    
                    if (data[4].Equals(location))
                    {
                        Contact contact = new Contact();
                        contact.ContactID = int.Parse(data[0]);
                        contact.Name = data[1];
                        contact.Mobile = data[2];
                        contact.Email = data[3];
                        contact.Location = data[4];
                        contacts.Add(contact);
                    }
                }
            }
            finally
            {
                reader.Close();
            }
            return contacts;
        }

        public void Save(Contact contact)
        {
            string contactCSV = $"{contact.ContactID},{contact.Name},{contact.Mobile}," +
                $"{contact.Email},{contact.Location}";
            StreamWriter sw = new StreamWriter(file, true);
            try
            {
                //if (!savedContactIDs.Contains(contact.ContactID))
                //{
                    savedContactIDs.Add(contact.ContactID);
                    sw.WriteLine(contactCSV);
                //}
                    
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
