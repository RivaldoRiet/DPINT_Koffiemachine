using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    public class StrengthDecorator : DrinkDecorator
    {
        private Strength strength { get; set; }
        public StrengthDecorator(IDrink setDrinkStrength, Strength strength) : base(setDrinkStrength)
        {
            this.strength = strength;
        }
        public override void LogDrinkMaking(ICollection<string> logText)
        {
            logText.Add($"Setting coffee strength to " + strength.ToString().ToLower() + ".");
            logText.Add("Filling with coffee...");
            this.Drink.LogDrinkMaking(logText);
        }
    }
}