using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    public class MilkDecorator : DrinkDecorator
    {
        private Amount milkAmount { get; set; }

        private double MilkPrice;

        public MilkDecorator(IDrink drink, Amount milkAmount) : base(drink)
        {
            MilkPrice = 0.15;
            this.milkAmount = milkAmount;
        }

        public override void LogDrinkMaking(ICollection<string> logText)
        {
            logText.Add($"Setting milk amount to " + milkAmount.ToString().ToLower() + ".");
            logText.Add("Adding milk...");
            this.Drink.LogDrinkMaking(logText);
        }

        public override double GetPrice()
        {
            return base.GetPrice() + MilkPrice;
        }

        public override string GetName()
        {
            return base.GetName() + " + Milk";
        }
    }
}
