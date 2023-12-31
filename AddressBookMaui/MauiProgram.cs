using AddressBook.Services;
using AddressBookMaui.MVVM.ViewModels;
using AddressBookMaui.MVVM.Views;
using AdsressBook.Models;
using Microsoft.Extensions.Logging;

namespace AddressBookMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

           
            builder.Services.AddSingleton<AddView>();
            builder.Services.AddSingleton<AddViewModel>();
            builder.Services.AddSingleton<ContactListView>();
            builder.Services.AddSingleton<ListViewModel>();
            builder.Services.AddSingleton<UpdateView>();
            builder.Services.AddSingleton<UpdateViewModel>();
            builder.Services.AddSingleton<AddressBookService>();
            builder.Services.AddSingleton<AddressBookContact>();


            builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}
