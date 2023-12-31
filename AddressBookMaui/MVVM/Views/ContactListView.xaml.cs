using AddressBookMaui.MVVM.ViewModels;

namespace AddressBookMaui.MVVM.Views;

public partial class ContactListView : ContentPage
{
	public ContactListView(ListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}