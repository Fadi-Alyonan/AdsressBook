namespace AdsressBook.Interfaces
{
    /// Interface for an address book contact.
    public interface IAddressBookContact
    {
        string Address { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
    }
}