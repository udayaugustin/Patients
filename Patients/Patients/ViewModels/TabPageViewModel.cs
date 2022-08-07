using Patients.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace Patients.ViewModels
{
    /// <summary>
    /// Class <c>PatientsTabPageViewModel</c> contains the business logic for Patient tab page.
    /// </summary>
    public class TabPageViewModel : BindableBase, IInitialize
    {
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// A constructor initializes the PatientsTabPageViewModel. 
        /// </summary>
        /// <param name="eventAggregator">The event aggregator service</param>
        public TabPageViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        /// <summary>
        /// A intialize method notifies the content view when the page is initailized.
        /// </summary>
        /// <param name="parameters">The naviagtion parameter</param>
        public void Initialize(INavigationParameters parameters)
        {
            eventAggregator.GetEvent<PageIntializeEvent>().Publish();
        }
    }
}
