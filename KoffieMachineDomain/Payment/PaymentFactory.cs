using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Payment
{
    public class PaymentFactory
    {

        private Dictionary<string, double> _cashOnCards;

        public PaymentFactory()
        {
            this.InitializeCashOnCards();
        }

        private void InitializeCashOnCards()
        {
            _cashOnCards = new Dictionary<string, double>();
            _cashOnCards["Arjen"] = 5.0;
            _cashOnCards["Bert"] = 3.5;
            _cashOnCards["Chris"] = 7.0;
            _cashOnCards["Daan"] = 6.0;
        }
        public double GetUsersCashOnCard(string name)
        {
            return _cashOnCards[name];
        }

        public double ChangeUsersCashOnCard(string name, double value)
        {
            return _cashOnCards[name] = value;
        }

        public IEnumerable<string> ConverterNames
        {
            get { return _cashOnCards.Keys; }
        }

    }
}
