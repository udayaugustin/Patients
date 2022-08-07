using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Patients.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        public DelegateCommand LoginCommand { get; set; }

        private string username;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        private string password;
        private readonly INavigationService navigationService;

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            LoginCommand = new DelegateCommand(async () => await Login(), CanLogin).ObservesProperty(() => Username).ObservesProperty(() => Password);
            this.navigationService = navigationService;
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);  
        }

        private async Task Login()
        {
            await navigationService.NavigateAsync("PatientsTabPage");
        }
    }
}
