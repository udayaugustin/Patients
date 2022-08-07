using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;

namespace Patients.ViewModels
{
    /// <summary>
    /// Class <c>LoginPageViewModel</c> contains the business logic for LoginPage.
    /// </summary>
    public class LoginPageViewModel : BindableBase, IInitialize
    {
        private string username;
        private string password;
        private readonly INavigationService navigationService;

        /// <summary>
        /// A Login command which validates the user and login to the application
        /// </summary>
        public DelegateCommand LoginCommand { get; set; }

        
        /// <summary>
        /// A property binded to the username control.
        /// </summary>
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }
                
        /// <summary>
        /// A property binded to password control.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        /// <summary>
        /// A contructor initializes the login page viewmodel. 
        /// </summary>
        /// <param name="navigationService">The navigation service</param>
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
            await navigationService.NavigateAsync("/NavigationPage/PatientsTabPage");
        }

        public void Initialize(INavigationParameters parameters)
        {
            
        }
    }
}
