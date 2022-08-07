using Prism.Mvvm;

namespace Patients.ViewModels
{
    /// <summary>
    /// A class <c>PatientViewModel<c> respresents the patient properties for the PatientTabView.
    /// </summary>
    public class PatientViewModel : BindableBase
    {
        private bool isVisible;

        /// <summary>
        /// A property which represents the name of the patient
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// A property which represents the age of the patient
        /// </summary>
        public int Age { get; set; }
        
        /// <summary>
        /// A property which represents the blood group of the patient
        /// </summary>
        public string BloodGroup { get; set; }

        /// <summary>
        /// A property which represents visibility of the patient details 
        /// </summary>        
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); }
        }
    }
}