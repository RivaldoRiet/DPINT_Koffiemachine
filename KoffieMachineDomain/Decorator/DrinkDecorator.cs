using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    public abstract class DrinkDecorator : IDrink
    {
        protected IDrink Drink;

        protected DrinkDecorator(IDrink drink)
        {
            this.Drink = drink;
        }

        public virtual void LogDrinkMaking(ICollection<string> logText)
        {
            this.Drink.LogDrinkMaking(logText);
        }

        public virtual double GetPrice()
        {
            return Drink.GetPrice();
        }

        public virtual string GetName()
        {
            return Drink.GetName();
        }

    }
}
