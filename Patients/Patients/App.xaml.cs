using Patients.ViewModels;
using Patients.Views;
using Prism;
using Prism.Ioc;
using Prism.Mvvm;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Patients
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/PatientsTabPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();            
            containerRegistry.RegisterForNavigation<PatientTabbedPage, PatientTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<PatientsListPage, PatientsListPageViewModel>();
            containerRegistry.RegisterForNavigation<PatientsTabPage, PatientsTabPageViewModel>();
            ViewModelLocationProvider.Register<PatientsView, PatientsViewModel>();
        }
    }
}
