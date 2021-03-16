using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Adapters
{
    public class Chocolate : Drink
    {
        private TeaAndChocoLibrary.HotChocolate _hotChocolate;

        public Chocolate(Boolean deluxe) : base()
        {
            _hotChocolate = new TeaAndChocoLibrary.HotChocolate();
            if (deluxe)
            {
                _hotChocolate.MakeDeluxe();
                BasePrice = _hotChocolate.Cost();
                BaseName = _hotChocolate.GetNameOfDrink();
            }
            else
            {
                BasePrice = _hotChocolate.Cost();
                BaseName = _hotChocolate.GetNameOfDrink();
            }

        }
        public override void LogDrinkMaking(ICollection<string> logText)
        {
            foreach (string s in _hotChocolate.GetBuildSteps())
            {
                logText.Add(s);
            }
        }
    }
}
