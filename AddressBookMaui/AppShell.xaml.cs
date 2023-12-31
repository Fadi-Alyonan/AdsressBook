using AddressBookMaui.MVVM.Views;

namespace AddressBookMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ContactListView), typeof(ContactListView));
            Routing.RegisterRoute(nameof(AddView), typeof(AddView));
            Routing.RegisterRoute(nameof(UpdateView), typeof(UpdateView));
        }
    }
}
