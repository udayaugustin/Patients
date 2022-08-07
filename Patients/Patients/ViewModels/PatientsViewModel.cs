using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Patients.ViewModels
{
    public class PatientsViewModel : BindableBase
    {
        private PatientViewModel _oldPatient;
        private ObservableCollection<PatientViewModel> allPatients;
        private ObservableCollection<PatientViewModel> patients;

        public ObservableCollection<PatientViewModel> Patients
        {
            get { return patients; }
            set
            {
                SetProperty(ref patients, value);
            }
        }

        private string searchQuery;
        public string SearchQuery
        {
            get { return searchQuery; }
            set
            {
                SetProperty(ref searchQuery, value);
                if (string.IsNullOrEmpty(searchQuery))
                    ResetPatientsData();
            }
        }

        private void ResetPatientsData()
        {
            Patients = allPatients;
        }

        public ICommand ToggleCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public PatientsViewModel()
        {
            ToggleCommand = new DelegateCommand
                <PatientViewModel>((p) => TogglePatientDetails(p));
            SearchCommand = new DelegateCommand(FilterPatients);

            allPatients = Patients = new ObservableCollection<PatientViewModel>
            {
                new PatientViewModel{Name="John Peterson", Age=20, BloodGroup="B+"},
                new PatientViewModel{Name="Thomas", Age=20, BloodGroup="B+"},
                new PatientViewModel{Name="Adam Savage", Age=20, BloodGroup="B+"},
                new PatientViewModel{Name="George", Age=20, BloodGroup="B+"},

            };
        }

        private void FilterPatients()
        {
            Patients = new ObservableCollection<PatientViewModel>(allPatients.Where(p => p.Name.Contains(SearchQuery)).ToList());
        }

        public void TogglePatientDetails(PatientViewModel patient)
        {
            if (_oldPatient == patient)
                patient.IsVisible = !patient.IsVisible;
            else
            {
                if (_oldPatient != null)
                    _oldPatient.IsVisible = false;

                patient.IsVisible = true;
            }
            
            _oldPatient = patient;
        }        
    }
}
