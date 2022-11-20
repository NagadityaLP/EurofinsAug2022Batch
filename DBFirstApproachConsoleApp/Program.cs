using DBFirstApproachConsoleApp.Data;
using System.Linq;
using System;

namespace DBFirstApproachConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get all contacts
            ContactsDbContext db = new ContactsDbContext();
            var contacts = db.contacts.ToList();

            foreach (var item in contacts)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
