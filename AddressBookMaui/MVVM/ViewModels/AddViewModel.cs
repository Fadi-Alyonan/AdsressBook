using AddressBook.Services;
using AddressBookMaui.MVVM.Views;
using AdsressBook.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;




namespace AddressBookMaui.MVVM.ViewModels;
// ViewModel for the AddContact view, responsible for handling the addition of new contacts.
public partial class AddViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;

    public AddViewModel(AddressBookService addressBookService)
    {
        _addressBookService = addressBookService;
        
    }

    // Gets or sets the contact being used for application.
    [ObservableProperty]
    private AddressBookContact contact = new();

    // Adds the specified contact to the address book.
    [RelayCommand]
    public async Task AddContact()
    {
        try
        {
            if (Contact != null && !string.IsNullOrWhiteSpace(Contact.Email))
            {
                if (_addressBookService.AddContact(Contact))
                {
                    Contact = new AddressBookContact();
                    await Shell.Current.GoToAsync($"//{nameof(ContactListView)}");
                    
                }

            }
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"An unhandled exception occurred: {ex}");
        }
    }
}
