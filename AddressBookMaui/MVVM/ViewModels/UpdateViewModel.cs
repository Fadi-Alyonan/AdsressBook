using AddressBook.Services;
using AddressBookMaui.MVVM.Views;
using AdsressBook.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace AddressBookMaui.MVVM.ViewModels;
// ViewModel for updating contact details, implementing IQueryAttributable for parameter passing.
public partial class UpdateViewModel : ObservableObject, IQueryAttributable
{
    private readonly AddressBookService _addressBookService;

    

    public UpdateViewModel(AddressBookService addressBookService)
    {
        _addressBookService = addressBookService;
        
    }

    // Gets or sets the contact being used for application.
    [ObservableProperty]
    private AddressBookContact contact = new();

    // Gets or sets the collection of contacts.
    [ObservableProperty]
    private ObservableCollection<AddressBookContact>? contacts;

    // Updates the contact details and navigates back to the contact list view.
    [RelayCommand]
    public async Task Update()
    {
        try
        {
            _addressBookService.UpdateContact(Contact);
            Contacts = new ObservableCollection<AddressBookContact>(_addressBookService.GetAllContacts(Contact));
            await Shell.Current.GoToAsync($"///{nameof(ContactListView)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating contact: {ex.Message}");
        }

    }
    // Applies query attributes to the ViewModel.
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Contact = (query["Contact"] as AddressBookContact)!;
    }
}
