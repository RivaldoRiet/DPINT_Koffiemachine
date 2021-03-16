using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<string> LogText { get; private set; }
        public DrinkViewModel DrinkViewModel { get; private set; }
        public PaymentViewModel PaymentViewModel { get; set; }

        public MainViewModel()
        {
            LogText = new ObservableCollection<string>();
            DrinkViewModel = new DrinkViewModel(LogText);
            PaymentViewModel = new PaymentViewModel(LogText, DrinkViewModel);
            this.StartCoffeeMachine();

        }

        private void StartCoffeeMachine()
        {
            LogText.Add("Starting up...");
            LogText.Add("Done, what would you like to drink?");
        }

    }
}