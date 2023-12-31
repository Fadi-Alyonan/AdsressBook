using AddressBook.Services;
using AdsressBook.Interfaces;
using AdsressBook.Models;
using System.Text.Json;


namespace AddressBookTests;
// Test class for the AddressBookService.
public class AddressBook_Tests : IDisposable
{
    private const string TestFilePath = "test_contacts.json";
    // Constructor to initialize the test class and delete the test file if it exists.
    public AddressBook_Tests()
    {
        if (File.Exists(TestFilePath))
        {
            File.Delete(TestFilePath);
        }
    }
    // Test method to verify that AddContact adds a contact to the list.
    [Fact]
    public void AddContact_ShouldAddContactToCutomerList()
    {
        // Arrange
        AddressBookService addressBookService = new AddressBookService();

        // Act
        var newContact = new AddressBookContact
        {
            FirstName = "test",
            LastName = "test",
            PhoneNumber = "987654321",
            Email = "test@example.com",
            Address = "testVa"
        };
        var result = addressBookService.AddContact(newContact);

        // Assert
        Assert.True(result);
        var loadedContacts = addressBookService.GetAllContacts(newContact);
        Assert.Contains(loadedContacts, c => c.Email == "test@example.com");
    }
    // Test method to verify that RemoveContact removes a contact from the list.
    [Fact]
    public void RemoveContact_ShouldRemoveContactFromList()
    {
        // Arrange
        IAddressBookService addressBookService = new AddressBookService();

        var contactToRemove = new AddressBookContact
        {
            FirstName = "test",
            LastName = "test",
            PhoneNumber = "987654321",
            Email = "test@example.com",
            Address = "testVa"
        };
        addressBookService.AddContact(contactToRemove);

        // Act
        addressBookService.RemoveContact(contactToRemove);

        // Assert
        var loadedContacts = LoadContacts();
        Assert.Empty(loadedContacts);
    }
    // Test method to verify that GetContactByEmail returns the correct contact.
    [Fact]
    public void GetContactByEmail_ShouldReturnContactIfExists()
    {
        // Arrange
        IAddressBookService addressBookService = new AddressBookService();

        var contactToAdd = new AddressBookContact
        {
            FirstName = "test",
            LastName = "test",
            PhoneNumber = "987654321",
            Email = "test@example.com",
            Address = "testVa"
        };
        addressBookService.AddContact(contactToAdd);

        // Act
        var retrievedContact = addressBookService.GetContactByEmail("test@example.com");

        // Assert
        Assert.NotNull(retrievedContact);
        Assert.Equal("test", retrievedContact?.FirstName);
        Assert.Equal("testVa", retrievedContact?.Address);
    }
    // Test method to verify that GetAllContacts returns all contacts.
    [Fact]
    public void GetAllContacts_ShouldReturnAllContacts()
    {
        // Arrange
        IAddressBookService addressBookService = new AddressBookService();

        var contactsToAdd = new List<AddressBookContact>
        {
            new AddressBookContact
            {
                FirstName = "test-1",
                LastName = "test-1",
                PhoneNumber = "987654321-1",
                Email = "test-1@example.com",
                Address = "testVa-1"
            },
            new AddressBookContact
            {
                FirstName = "test-2",
                LastName = "test-2",
                PhoneNumber = "987654321-2",
                Email = "test-2@example.com",
                Address = "testVa-2"
            }
        };
        AddressBookContact expectedContact = new AddressBookContact
        {
            FirstName = "test",
            LastName = "test",
            PhoneNumber = "987654321",
            Email = "test@example.com",
            Address = "testVa"
        };
        // Act
        foreach (var contact in contactsToAdd)
        {
            addressBookService.AddContact(contact);
        }

        var allContacts = addressBookService.GetAllContacts(expectedContact);

        // Assert
        Assert.NotEmpty(allContacts);
        Assert.Equal(2, allContacts.Count);
    }

    // Helper method to load contacts from the test file.
    [Fact]
    private List<AddressBookContact> LoadContacts()
    {
        try
        {
            if (File.Exists(TestFilePath))
            {
                string json = File.ReadAllText(TestFilePath);
                return JsonSerializer.Deserialize<List<AddressBookContact>>(json) ?? new List<AddressBookContact>();
            }
            else
            {
                return new List<AddressBookContact>();
            }
        }
        catch (Exception)
        {
            return new List<AddressBookContact>();
        }
    }
    // Test method to dispose of resources after tests.
    public void Dispose()
    {
        if (File.Exists(TestFilePath))
        {
            File.Delete(TestFilePath);
        }
    }
}
