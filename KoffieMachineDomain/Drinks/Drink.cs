using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public abstract class Drink : IDrink
    {

        protected double BasePrice;

        public virtual double GetPrice()
        {
            return BasePrice;
        }

        protected string BaseName;

        public virtual string GetName()
        {
            return BaseName;
        }

        public Drink()
        {
            BasePrice = 1.0;
        }

        public virtual void LogDrinkMaking(ICollection<string> logText)
        {
            logText.Add($"Making {GetName()}...");
            logText.Add($"Heating up...");
        }

    }
}
