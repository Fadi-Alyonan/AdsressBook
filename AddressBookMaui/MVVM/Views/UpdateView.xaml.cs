using AddressBookMaui.MVVM.ViewModels;

namespace AddressBookMaui.MVVM.Views;

public partial class UpdateView : ContentPage
{
	public UpdateView(UpdateViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}