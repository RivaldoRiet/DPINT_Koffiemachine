using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    public class DrinkAmountDecorator : DrinkDecorator
    {
        public virtual Amount DrinkAmount { get; set; }

        public DrinkAmountDecorator(IDrink drink, Amount DrinkAmount) : base(drink)
        {
            this.DrinkAmount = DrinkAmount;
        }

        public override void LogDrinkMaking(ICollection<string> logText)
        {
            logText.Add($"Setting drink amount to " + DrinkAmount.ToString().ToLower() + ".");
            this.Drink.LogDrinkMaking(logText);
        }

    }
}
