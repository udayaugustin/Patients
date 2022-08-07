using Patients.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Patients.ViewModels
{
    /// <summary>
    /// A class <c>PatientTabViewModel</c> contains the business logic for patient tab view.
    /// </summary>
    public class PatientTabViewModel : BindableBase
    {
        private PatientViewModel _oldPatient;
        private ObservableCollection<PatientViewModel> allPatients;
        private ObservableCollection<PatientViewModel> patients;
        private string searchQuery;
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// A property respresents the collection of patient view model records.
        /// </summary>
        public ObservableCollection<PatientViewModel> Patients
        {
            get { return patients; }
            set
            {
                SetProperty(ref patients, value);
            }
        }

        /// <summary>
        /// A property respresents the search query. 
        /// </summary>
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

        /// <summary>
        /// A command handles the listview's plus icon client event.
        /// </summary>
        public ICommand ToggleCommand { get; set; }

        /// <summary>
        /// A command which is binded to search bar
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// A constructor initializes the PatientTabViewModel. 
        /// </summary>
        /// <param name="eventAggregator">The event aggregator service</param>
        public PatientTabViewModel(IEventAggregator eventAggregator)
        {
            ToggleCommand = new DelegateCommand
                <PatientViewModel>((p) => TogglePatientDetails(p));
            SearchCommand = new DelegateCommand(FilterPatients);
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<PageIntializeEvent>().Subscribe(Initialize);
        }

        private void Initialize()
        {
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

        private void TogglePatientDetails(PatientViewModel patient)
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

        private void ResetPatientsData()
        {
            Patients = allPatients;
        }
    }
}
