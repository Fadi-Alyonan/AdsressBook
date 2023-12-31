using AdsressBook.Models;

namespace AdsressBook.Interfaces
{
    /// Interface for an address book svervice.
    public interface IAddressBookService
    {
        event EventHandler? ContactsUpdate;

        bool AddContact(AddressBookContact contact);
        List<AddressBookContact> GetAllContacts(AddressBookContact contact);
        AddressBookContact? GetContactByEmail(string email);
        void RemoveContact(AddressBookContact contact);
        void UpdateContact(AddressBookContact contact);
    }
}