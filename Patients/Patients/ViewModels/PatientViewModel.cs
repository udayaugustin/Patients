using Prism.Mvvm;

namespace Patients.ViewModels
{
    public class PatientViewModel : BindableBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); }
        }
    }
}