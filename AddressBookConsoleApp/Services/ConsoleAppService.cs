using AddressBook.Services;
using AdsressBook.Models;

namespace AddressBookConsoleApp.Services;

public class ConsoleAppService
{
    private AddressBookContact contact = new();

    // Add a contact to the list
    public void AddContact(AddressBookService addressBookService)
    {
        Console.WriteLine("Add Contact:");
        var contact = new AddressBookContact()!;

        Console.Write("First Name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Phone Number: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("Email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Address: ");
        contact.Address = Console.ReadLine()!;

        if (addressBookService.AddContact(contact))
        {
            Console.WriteLine("");
            Console.WriteLine("Contact added successfully.");
        }
        else
        {
            Console.WriteLine("Failed to add contact try with a different email address.");
        }
    }
    // Display all contacts
    public void ListAllContacts(AddressBookService addressBookService)
    {

       
        var contacts = addressBookService.GetAllContacts(contact);

        if (contacts != null && contacts.Count != 0)
        {
            Console.WriteLine("All Contacts:");
            Console.WriteLine("");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}, Email: {contact.Email}");
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("Contact not found try to add new contact.");
        }

    }
    // Display details of a specific contact
    public void ViewContactDetails(AddressBookService addressBookService)
    {
        Console.Write("Enter Email to view contact details: ");
        string email = Console.ReadLine()!;

        var contact = addressBookService.GetContactByEmail(email);

        if (contact != null)
        {
            Console.WriteLine("");
            Console.WriteLine($"Contact Details:");
            Console.WriteLine("");
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine("");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine("");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine("");
            Console.WriteLine($"Address: {contact.Address}");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
    // Remove a contact from the list
    public void RemoveContact(AddressBookService addressBookService)
    {
        Console.Write("Enter Email to remove contact: ");
        string email = Console.ReadLine()!;

        addressBookService.RemoveContact(addressBookService.GetContactByEmail(email)!);
        Console.WriteLine("");
        Console.WriteLine("Contact removed successfully.");
    }
}


