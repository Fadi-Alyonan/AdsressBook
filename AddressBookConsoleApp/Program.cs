using AddressBook.Services;
using AddressBookConsoleApp.Services;
using AdsressBook.Interfaces;
class Program
{
    // Main program to instantiate and run the address book console application
    static void Main()
    {
        // Console application logic for interacting with the address book service
        AddressBookService addressBookService = new();
        ConsoleAppService consoleAppService = new();

        while (true)
        {
            Console.WriteLine("Address Book Console App");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. List All Contacts");
            Console.WriteLine("3. View Contact Details");
            Console.WriteLine("4. Remove Contact");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine()!;
            Console.WriteLine("");
            switch (choice)
            {
                case "1":
                    consoleAppService.AddContact(addressBookService);
                    break;
                case "2":
                    consoleAppService.ListAllContacts(addressBookService);
                    break;
                case "3":
                    consoleAppService.ViewContactDetails(addressBookService);
                    break;
                case "4":
                    consoleAppService.RemoveContact(addressBookService);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

            Console.WriteLine();
        }
    }
}