using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public interface IDrink
    {
        string GetName();
        void LogDrinkMaking(ICollection<string> logText);
        double GetPrice();

    }
}
