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

        Strength _coffeeStrength;
        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; LogText.Add($"Coffee strength: {CoffeeStrength}"); }
        }

        private Amount _sugarAmount;
        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; LogText.Add($"Sugar amount: {SugarAmount}"); }
        }

        private Amount _milkAmount;
        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; LogText.Add($"Milk amount: {_milkAmount}"); }
        }

        private string _selectedTeaBlend;
        public string SelectedTeaBlend
        {
            get { return _selectedTeaBlend; }
            set { _selectedTeaBlend = value; LogText.Add($"Tea blend : {SelectedTeaBlend}"); }
        }


        public ICommand SelectedDrinkCommand { get; set; }

        public IDrink SelectedDrink;

        public ObservableCollection<string> LogText { get; private set; }

        public ObservableCollection<string> TeaBlendOptions { get; set; }

        private DrinkFactory _drinkFactory;

        public DrinkViewModel(ObservableCollection<string> LogText)
        {
            this.LogText = LogText;
            _drinkFactory = new DrinkFactory();
            SelectedDrinkCommand = new RelayCommand<string>(SelectDrink);
            //TEA
            TeaBlendOptions = new ObservableCollection<string>(_drinkFactory.TeaBlendNames);
            SelectedTeaBlend = TeaBlendOptions[1];
            LogText.Clear();
        }

        private void SelectDrink(string drinkName)
        {
            SelectedDrink = _drinkFactory.CreateDrink(drinkName, LogText, MilkAmount, SugarAmount, CoffeeStrength, SelectedTeaBlend);
            Notify(this);
        }

    }
}
