using System;
using System.Collections.Generic;
using System.Linq;

namespace exceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            // Linq stuff -------------------------------------------------------------------------------//
            Dictionary<string, double> DonutDictionary = new Dictionary<string, double>()
            { { "Old Fashioned", 2.20 }, { "Blueberry", 2.00 }
            };

            foreach (KeyValuePair<string, double> donut in DonutDictionary)
            {
                Console.WriteLine($"A {donut.Key} costs ${donut.Value}");
            }

            try
            {
                //code where problem occurs
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            //LINQ Time! Language-Integrated Query. Extension Methods 
            List<double> DonutPrices = new List<double>()
            {
                1.00,
                2.00,
                2.30,
                .99
            };

            // Find most expensive donut
            double mostExpensive = DonutPrices.Max();

            Console.WriteLine($"The most expensive donut costs ${mostExpensive}");
            Console.WriteLine($"The least expensive donut costs ${DonutPrices.Min()}");
            Console.WriteLine($"The total of all donut costs ${DonutPrices.Sum()}");
            Console.WriteLine($"The average cost of all donuts ${DonutPrices.Average()}");

            List<string> donutNames = DonutDictionary.Select(donut => { return donut.Key; }).ToList();
            Console.WriteLine("I'm a MF list of Donut Names created by a ToList() !....");
            donutNames.ForEach(name => Console.WriteLine($"{name}"));

            //            Dictionary<string, double> cheapestDonuts = DonutDictionary.Where(donut => donut.Value < 2.00).ToList();
            // End Linq stuff -------------------------------------------------------------------------------//

            // Try / Catch Stuff -------------------->
            Console.WriteLine("........................ Try / Catch Practice ........................");
            try
            {
                Calculator calculator = new Calculator();
                int stupidAnswer = calculator.Divide(42, 0);
                Console.WriteLine($"Calc answer or error: ${stupidAnswer}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Well, you can't do that - This would blow up a robot in Lost In Space or Star Trek..");
                Console.Write($"Here's the actual error: {ex.Message}");
            }
            // More Try / Catch
            Console.WriteLine("..................Try/Catch Employee......................................");
            Company chickenShack = new Company() { Name = "Greasy Pete's Chicken Shack" };
            chickenShack.AddEmployee(new Employee() { FirstName = "Pete", LastName = "Shackleton" });
            chickenShack.AddEmployee(new Employee() { FirstName = "Molly", LastName = "Frycook" });
            chickenShack.AddEmployee(new Employee() { FirstName = "Pat", LastName = "Buttersmith" });

            List<int> employeeIds = new List<int>() { 0, 11, 2 };
            foreach (int id in employeeIds)
            {
                try
                {

                    Employee employee = chickenShack.GetEmployeeById(id);
                    Console.WriteLine($"Employee #{id} is {employee.FirstName} {employee.LastName}.");

                }
                catch (ArgumentOutOfRangeException ex)
                {
                    // Console.WriteLine("These aren't the droids you're looking for.");
                    // Console.WriteLine($"Here's the actual error for Arg out of range: {ex.Message}");
                    Console.WriteLine($"Employee #{id} was not found in the company.");
                }
            }

            // Try / Catch Practice Exercise ........................................................
            // Create a few contacts
            Contact bob = new Contact()
            {
                FirstName = "Bob", LastName = "Smith",
                Email = "bob.smith@email.com",
                Address = "100 Some Ln, Testville, TN 11111"
            };
            Contact sue = new Contact()
            {
                FirstName = "Sue", LastName = "Jones",
                Email = "sue.jones@email.com",
                Address = "322 Hard Way, Testville, TN 11111"
            };
            Contact juan = new Contact()
            {
                FirstName = "Juan", LastName = "Lopez",
                Email = "juan.lopez@email.com",
                Address = "888 Easy St, Testville, TN 11111"
            };

            // Create an AddressBook and add some contacts to it
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact(bob);
            addressBook.AddContact(sue);
            addressBook.AddContact(juan);

            // Try to addd a contact a second time
            addressBook.AddContact(sue);

            // Create a list of emails that match our Contacts
            List<string> emails = new List<string>()
            {
                "sue.jones@email.com",
                "juan.lopez@email.com",
                "bob.smith@email.com",
            };

            // Insert an email that does NOT match a Contact
            emails.Insert(1, "not.in.addressbook@email.com");

            //  Search the AddressBook by email and print the information about each Contact
            foreach (string email in emails)
            {
                try
                {
                    Contact contact = addressBook.GetByEmail(email);
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Name: {contact.FullName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Address: {contact.Address}");
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine($"Contact not found - {ex.Message}");
                }

            }

        }
    }
}