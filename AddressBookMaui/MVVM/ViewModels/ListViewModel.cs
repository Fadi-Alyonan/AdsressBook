using AddressBook.Services;
using AddressBookMaui.MVVM.Views;
using AdsressBook.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AddressBookMaui.MVVM.ViewModels;
// ViewModel for the contact list view, responsible for managing and displaying contacts.
public partial class ListViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;
    
    public ListViewModel(AddressBookService addressBookService)
    {
        _addressBookService = addressBookService;
        GetAllContacts();
        _addressBookService.ContactsUpdate += (sender, e) =>
        {
            Contacts = new ObservableCollection<AddressBookContact>(_addressBookService.GetAllContacts(contact));
        };
    }

    // Gets or sets the contact being used for application.
    [ObservableProperty]
    private AddressBookContact contact = new();

    // Gets or sets the collection of contacts.
    [ObservableProperty]
    private ObservableCollection<AddressBookContact>? contacts;

    // Gets all contacts from the list.
    [RelayCommand]
    public void GetAllContacts()
    {
        Contacts = new ObservableCollection<AddressBookContact>(_addressBookService.GetAllContacts(Contact));
    }

    // Removes the specified contact from the list.
    [RelayCommand]
    public void RemoveContact(AddressBookContact contact)
    {
        try
        {
            _addressBookService.RemoveContact(contact);
            Contacts = new ObservableCollection<AddressBookContact>(_addressBookService.GetAllContacts(contact));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing contact: {ex.Message}");
        }
       
    }

    // Navigates to the AddView for adding a new contact page.
    [RelayCommand]
    public async Task NavigateToAdd(AddressBookContact contact)
    {
        await Shell.Current.GoToAsync($"{nameof(AddView)}");
    }

    // Navigates to the UpdateView for updating an existing contact.
    [RelayCommand]
    public static async Task NavigateToUpdate(AddressBookContact contact)
    {

        var parameters = new ShellNavigationQueryParameters
        {
        { "Contact", contact }
        };

        await Shell.Current.GoToAsync($"{nameof(UpdateView)}", parameters);
    }
}
