using System;
using System.Collections.Generic;

namespace exceptions
{

    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string Address { get; set; }
        public string Email { get; set; }
    }

    public class AddressBook
    {
        private Dictionary<string, Contact> Contacts = new Dictionary<string, Contact>();

        public void AddContact(Contact aContact)
        {
            try
            {
                Contacts.Add(aContact.Email, aContact);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"This contact has already been added {ex.Message}");
            }

        }

        public Contact GetByEmail(string Email)
        {
            return Contacts[Email];

        }
    }
}