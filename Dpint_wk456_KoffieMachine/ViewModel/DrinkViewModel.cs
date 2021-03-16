using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using KoffieMachineDomain.Factory;
using KoffieMachineDomain.Observer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class DrinkViewModel : Observable<DrinkViewModel>
    {
        public ICommand SelectedDrinkCommand { get; set; }
        public IDrink SelectedDrink;
        public ObservableCollection<string> LogText { get; private set; }
        public ObservableCollection<string> TeaBlendChoices { get; set; }
        private readonly DrinkFactory _drinkFactory;

        public DrinkViewModel(ObservableCollection<string> logText)
        {
            this.LogText = logText;
            _drinkFactory = new DrinkFactory();
            SelectedDrinkCommand = new RelayCommand<string>(SelectDrink);
            TeaBlendChoices = new ObservableCollection<string>(_drinkFactory.TeaBlendNames);
            SelectedTeaBlend = TeaBlendChoices[1];
            logText.Clear();
        }

        private void SelectDrink(string name)
        {
            SelectedDrink = _drinkFactory.ProduceDrink(name, LogText, MilkAmount, SugarAmount, CoffeeStrength, SelectedTeaBlend);
            Notify(this);
        }

        public Strength CoffeeStrength { get; set; }

        public Amount SugarAmount { get; set; }

        public Amount MilkAmount { get; set; }

        private string _selectedTeaBlend;

        public string SelectedTeaBlend
        {
            get { return _selectedTeaBlend; }
            set
            {
                _selectedTeaBlend = value;
                LogText.Add($"Tea blend : {SelectedTeaBlend}" + ".");
            }
        }
    }
}
