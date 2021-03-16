using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorator
{
    public abstract class BaseDrinkDecorator : IDrink
    {
        protected IDrink Drink;

        protected BaseDrinkDecorator(IDrink drink)
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
