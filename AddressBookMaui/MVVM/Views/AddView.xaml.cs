using AddressBookMaui.MVVM.ViewModels;

namespace AddressBookMaui.MVVM.Views;

public partial class AddView : ContentPage
{
	public AddView(AddViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;
	}
}