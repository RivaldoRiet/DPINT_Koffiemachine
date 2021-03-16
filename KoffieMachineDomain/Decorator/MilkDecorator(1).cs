using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    public class MilkDecorator : BaseDrinkDecorator
    {

        public virtual Amount MilkAmount { get; set; }

        private double MilkPrice;

        public MilkDecorator(IDrink drink, Amount milkAmount) : base(drink)
        {
            MilkPrice = 0.15;
            this.MilkAmount = milkAmount;
        }

        public override void LogDrinkMaking(ICollection<string> logText)
        {
            logText.Add($"Setting milk amount to {MilkAmount}.");
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
