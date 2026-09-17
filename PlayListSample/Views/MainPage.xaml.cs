using PlayListSample.Services;
using PlayListSample.ViewModels;

namespace PlayListSample.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        
        // יצירה והקצאה ישירה של ה-ViewModel ללא DI Container מורכב
        // כדי שהתלמיד יראה בבירור את החיבור בין ה-View, ה-ViewModel וה-Service
        BindingContext = new MainViewModel(new MockVideoService());
    }
}
