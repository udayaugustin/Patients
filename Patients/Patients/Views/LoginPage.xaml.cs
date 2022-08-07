using Plugin.MaterialDesignControls;
using Xamarin.Forms;

namespace Patients.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            MaterialEntry a = new MaterialEntry();
            entry.CustomTrailingIcon.WidthRequest = 60;
        }

        private void CustomEntry_Focused(object sender, FocusEventArgs e)
        {

        }
    }
}
