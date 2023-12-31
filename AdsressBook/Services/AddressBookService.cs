using AdsressBook.Interfaces;
using AdsressBook.Models;
using System.Diagnostics;
using System.Text.Json;

namespace AddressBook.Services;
/// Implementation of the IAddressBookService interface.
/// Manages the address book functionality and data persistence.
public class AddressBookService : IAddressBookService
{

    private readonly string _filePath;

    public event EventHandler? ContactsUpdate;

    public List<AddressBookContact> contacts = [];


    public AddressBookService()
    {
        contacts = new List<AddressBookContact>();
        _filePath = Path.Combine(AppContext.BaseDirectory, "contacts.json");

    }

    // Add a contact to the list and persist to file
    public bool AddContact(AddressBookContact contact)
    {

        try
        {
            if (!contacts.Any(c => c.Email.Equals(contact.Email, StringComparison.OrdinalIgnoreCase)))
            {
                contacts.Add(contact);
                SaveContacts(GetOptions());
                ContactsUpdate?.Invoke(this, EventArgs.Empty);
                return true;
            }
            else
            {
                Debug.WriteLine($"Contact with email '{contact.Email}' already exists.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"An error occurred while adding a contact: {ex.Message}");
            return false;
        }
    }

    // Remove a contact from the list and persist to file
    public void RemoveContact(AddressBookContact contact)
    {
        try
        {
            contacts.Remove(contact);
            SaveContacts(GetOptions());
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error removing contact: {ex.Message}");
        }
    }

    // Update contact details in the list and persist to file
    public void UpdateContact(AddressBookContact contact)
    {
        try
        {
            if (contact != null)
            {
                var addressBookContact = contacts.FirstOrDefault(c => c.Email == contact.Email);

                if (addressBookContact != null)
                {
                    addressBookContact.FirstName = contact.FirstName;
                    addressBookContact.LastName = contact.LastName;
                    addressBookContact.Email = contact.Email;
                    addressBookContact.PhoneNumber = contact.PhoneNumber;
                    addressBookContact.Address = contact.Address;

                    SaveContacts(GetOptions());
                    ContactsUpdate?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    Debug.WriteLine($"Contact with email '{contact.Email}' not found.");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating contact: {ex.Message}");
        }
    }

    // Display details of a specific contact
    public AddressBookContact? GetContactByEmail(string email)
    {
        LoadContacts();
        return contacts.Find(c => c.Email == email);
    }

    // Display all contacts
    public List<AddressBookContact> GetAllContacts(AddressBookContact contact)
    { 
        LoadContacts();
        return contacts;
    }

    // Load contacts from a JSON file
    private void LoadContacts()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                contacts = JsonSerializer.Deserialize<List<AddressBookContact>>(json) ?? [];
            }
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"An error occurred while loading contacts: {ex.Message}");
            contacts = [];
        }
    }

    // Get JSON serialization options
    private static JsonSerializerOptions GetOptions()
    {
        return new() { WriteIndented = true };
    }
    // Save contacts to a JSON file
    private void SaveContacts(JsonSerializerOptions options)
    {
        try
        {
            string json = JsonSerializer.Serialize(contacts, options);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"An error occurred while saving contacts: {ex.Message}");
        }
    }
}