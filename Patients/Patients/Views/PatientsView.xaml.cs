using Patients.Models;
using Patients.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Patients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientsView : ContentView
    {
        
        public PatientsView()
        {
            InitializeComponent();                       
        }        
    }
}