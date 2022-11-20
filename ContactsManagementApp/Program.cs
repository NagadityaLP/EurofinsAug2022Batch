using ContactsManagementApp.Data;
using ContactsManagementApp.Entities;
using System.Collections.Generic;
using System;

namespace ContactsManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Contact c = new Contact { Name = "Sachin", Email = "sachin@bcci.org", Mobile = "2345678966", Location = "Mumbai" };
            Contact d = new Contact { Name = "Aditya", Email = "aditya@bcci.org", Mobile = "2345678966", Location = "Tumkur" };
            Contact e = new Contact { Name = "Nagaditya", Email = "nagaaditya@bcci.org", Mobile = "2345678966", Location = "TumkurSmartCity" };

            IContactsRepository repo = new ContactsDBRepository();
            /*repo.Save(c);
            repo.Save(d);
            Console.WriteLine("Contact saved");*/

            //repo.Delete(2);
            //Console.WriteLine("Contact deleted");

            //repo.Edit(5, e);
            //Console.WriteLine("Contact edited");

            /*Contact f = repo.GetContactById(5);
            Console.WriteLine(f.Name);
            Console.WriteLine(f.Email);
            Console.WriteLine(f.Mobile);
            Console.WriteLine(f.Location);
            Console.WriteLine(f.ContactID);*/

            //display(repo.GetContacts());
            display(repo.GetContactsByLocation("Mumbai"));






            /*ContactsFileRepository repository = new ContactsFileRepository();

            while (true)
            {
                int choice;
                //List<Contact> contacts = new List<Contact>();
                Console.WriteLine("\nEnter your choice : 1. Create new contact  2. Get All Contacts 3. Get Contact by Id" +
                    "  4. Get contact by location  5. Edit contact  6. Delete contact 7. Break");
                choice = int.Parse(Console.ReadLine());

                if (choice == 7) break;

                switch (choice)
                {
                    case 1:
                        repository.Save(createContact());
                        break;
                    case 2:
                        display(repository.GetContacts());
                        break;
                    case 3:
                        Console.Write("Enter the Contact ID : ");
                        int id = int.Parse(Console.ReadLine());

                        display(repository.GetContactById(id));
                        break;
                    case 4:
                        Console.Write("Enter the contact's location : ");
                        string location = Console.ReadLine();

                        display(repository.GetContactsByLocation(location));
                        break;
                    case 5:
                        Console.Write("Enter the ID of the contact to be edited : ");
                        int id1 = int.Parse(Console.ReadLine());
                        repository.Edit(id1, createContact());
                        break;
                    case 6:
                        Console.Write("Enter the ID of the contact to be deleted : ");
                        int id2 = int.Parse(Console.ReadLine());
                        repository.Delete(id2);
                        break;
                    default:
                        Console.WriteLine("You had entered an invalid choice");
                        break;
                }
            }*/
            
        }

        private static Contact createContact()
        {
            Contact contact = new Contact();
            Console.WriteLine("Enter contact details :");
            Console.Write("Name : ");
            contact.Name = Console.ReadLine();
            Console.Write("Contact ID : ");
            contact.ContactID = int.Parse(Console.ReadLine());
            Console.Write("Mobile : ");
            contact.Mobile = Console.ReadLine();
            Console.Write("Email : ");
            contact.Email = Console.ReadLine();
            Console.Write("Location : ");
            contact.Location = Console.ReadLine();

            return contact;
        }
        private static void display(List<Contact> contacts)
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"{contact.ContactID}{contact.Name}{contact.Mobile}{contact.Email}{contact.Location}");
            }
        }
        private static void display(Contact contact)
        {
            if (contact.ContactID == 0)
                Console.WriteLine("Contact not found");
            else
                Console.WriteLine($"{contact.ContactID}, {contact.Name}, {contact.Mobile}," +
                    $" {contact.Email}, {contact.Location}");
        }
    }
}




/*ContactsFileRepository repository = new ContactsFileRepository();
            Contact contact1 = new Contact();
            contact1.Name = "Aditya";
            contact1.Email = "aditya1234@gmail.com";
            contact1.ContactID = 01;
            contact1.Mobile = "5656787890";
            contact1.Location = "Tumkur";

            Contact contact2 = new Contact();
            contact2.Name = "Skanda";
            contact2.Email = "skanda5678@gmail.com";
            contact2.ContactID = 02;
            contact2.Mobile = "8765456785";
            contact2.Location = "Tumkur";

            Contact contact3 = new Contact();
            contact3.Name = "Murthy";
            contact3.Email = "murthy1234@gmail.com";
            contact3.ContactID = 03;
            contact3.Mobile = "7767543212";
            contact3.Location = "Tumkur";

            Contact contact4 = new Contact();
            contact4.Name = "Anand";
            contact4.Email = "anand1234@gmail.com";
            contact4.ContactID = 04;
            contact4.Mobile = "2256578904";
            contact4.Location = "Tumkur";
            
            repository.Save(contact1);
            repository.Save(contact2);
            repository.Save(contact3);
            repository.Save(contact4);


            List<Contact> contacts = new List<Contact>();
            contacts = repository.GetContacts();
            foreach (Contact contact in contacts)
            {
                System.Console.WriteLine($"{contact.ContactID}, {contact.Name}, {contact.Mobile}," +
                $" {contact.Email}, {contact.Location}");
            }
            *//*Contact contact7 = new Contact();
            contact7 = repository.GetContactById(07);
            System.Console.WriteLine($"\n{contact7.ContactID}, {contact7.Name}, {contact7.Mobile}," +
                $" {contact7.Email}, {contact7.Location}");*//*
            repository.Delete(02);
            System.Console.WriteLine($"\nAfter deleting");
            contacts = repository.GetContacts();
            foreach (Contact contact in contacts)
            {
                System.Console.WriteLine($"{contact.ContactID}, {contact.Name}, {contact.Mobile}," +
                $" {contact.Email}, {contact.Location}");
            }*/