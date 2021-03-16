using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    public class SugarDecorator : DrinkDecorator
    {
        private Amount sugarAmount { get; set; }
        private double sugarPrice;

        public SugarDecorator(IDrink setDrinkSugar, Amount sugarAmount) : base(setDrinkSugar)
        {
            sugarPrice = 0.1;
            this.sugarAmount = sugarAmount;
        }
        public override double GetPrice()
        {
            return base.GetPrice() + sugarPrice;

        }
        public override void LogDrinkMaking(ICollection<string> logText)
        {
            logText.Add($"Setting sugar amount to " + sugarAmount.ToString().ToLower() + ".");
            logText.Add("Adding sugar...");
            this.Drink.LogDrinkMaking(logText);
        }


        public override string GetName()
        {
            return base.GetName() + " + Sugar";
        }

    }
}

