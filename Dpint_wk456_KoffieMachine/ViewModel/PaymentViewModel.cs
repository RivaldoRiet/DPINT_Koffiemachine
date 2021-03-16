using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using KoffieMachineDomain.Payment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class PaymentViewModel : ViewModelBase, IObserver<DrinkViewModel>
    {
        public ObservableCollection<string> LogText { get; private set; }
        public ObservableCollection<string> PaymentCardUsernames { get; set; }
        public ICommand CardCommand { get; set; }
        public ICommand CoinCommand { get; set; }
        public IDrink SelectedDrink { get; set; }

        private readonly PaymentFactory _paymentFactory;
        private double _spareChange;
        public PaymentViewModel(ObservableCollection<string> logText, DrinkViewModel drinkViewModel)
        {
            LogText = logText;
            drinkViewModel.Subscribe(this);
            _paymentFactory = new PaymentFactory();
            PaymentCardUsernames = new ObservableCollection<string>(_paymentFactory.ConverterNames);
            SelectedPaymentCardUsername = PaymentCardUsernames[0];
            CoinCommand = new RelayCommand<double>(coinValue => { CoinPayment(insertedMoney: coinValue); });
            CardCommand = new RelayCommand(CardPayment);
        }

        public double PaymentCardRemainingAmount => _paymentFactory.ConverterNames.Contains(SelectedPaymentCardUsername ?? "") ? _paymentFactory.GetUsersCashOnCard(SelectedPaymentCardUsername) : 0;

        private string _selectedPaymentCardUsername;
        public string SelectedPaymentCardUsername
        {
            get { return _selectedPaymentCardUsername; }
            set
            {
                _selectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }

        }

        private double _moneyLeft;
        public double MoneyLeft
        {
            get { return _moneyLeft; }
            set { _moneyLeft = value; RaisePropertyChanged(() => MoneyLeft); }
        }


        private void CoinPayment(double insertedMoney)
        {
            if (SelectedDrink == null) return;
            MoneyLeft = CoinPayment(insertedMoney, MoneyLeft, null, LogText);
            CheckToCreateDrink();
        }

        private void CardPayment()
        {
            if (SelectedDrink != null)
            {
                var insertedMoney = _paymentFactory.GetUsersCashOnCard(SelectedPaymentCardUsername);
                MoneyLeft = PayWithCard(insertedMoney, MoneyLeft, SelectedPaymentCardUsername, LogText);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
                CheckToCreateDrink();
            }
        }

        private bool TransactionFinished()
        {
            return MoneyLeft <= 0;
        }
        private void CheckToCreateDrink()
        {
            if (TransactionFinished())
            {
                SelectedDrink.LogDrinkMaking(LogText);
                LogText.Add("------------------");
                SelectedDrink = null;
            }
        }

        public double CoinPayment(double insertedMoney, double remainingMoney, string selectedPaymentCardUsername, ICollection<string> logText)
        {
            var remainingPriceToPay = Math.Max(Math.Round(remainingMoney - insertedMoney, 2), 0);
            logText.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {remainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");
            if (!(insertedMoney > remainingMoney)) return remainingPriceToPay;
            _spareChange = insertedMoney - remainingMoney;
            logText.Add($"Spare change: {_spareChange.ToString("C", CultureInfo.CurrentCulture)}.");
            return remainingPriceToPay;
        }

        public double PayWithCard(double insertedMoney, double remainingMoney, string selectedPaymentCardUsername, ICollection<string> logText)
        {
            if (!(remainingMoney <= _paymentFactory.GetUsersCashOnCard(selectedPaymentCardUsername)))
            {
                insertedMoney = _paymentFactory.GetUsersCashOnCard(selectedPaymentCardUsername);
                remainingMoney -= insertedMoney;
                _paymentFactory.ChangeUsersCashOnCard(selectedPaymentCardUsername, 0);
            }
            else
            {
                var newValue = _paymentFactory.GetUsersCashOnCard(selectedPaymentCardUsername);
                newValue -= remainingMoney;
                _paymentFactory.ChangeUsersCashOnCard(selectedPaymentCardUsername, newValue);
                remainingMoney = 0;
            }

            logText.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {remainingMoney.ToString("C", CultureInfo.CurrentCulture)}.");

            return remainingMoney;
        }
        public void OnNext(DrinkViewModel value)
        {
            if (value.SelectedDrink != null)
            {
                SelectedDrink = value.SelectedDrink;
                MoneyLeft = value.SelectedDrink.GetPrice();
            }
        }
        public void OnError(Exception error)
        {
            const string filePath = @"C:\Error.txt";
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(
                    $"Message :{error.Message}<br/>{Environment.NewLine}StackTrace :{error.StackTrace}{Environment.NewLine}Date :{DateTime.Now}");
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
        public void OnCompleted()
        {
        }
    }
}
