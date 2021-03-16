using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Adapters
{
    public class AdapterChocolate : Drink
    {
        protected TeaAndChocoLibrary.HotChocolate _hotChocolate;

        public AdapterChocolate() : base()
        {
            _hotChocolate = new TeaAndChocoLibrary.HotChocolate();
            BasePrice = _hotChocolate.Cost();
            BaseName = _hotChocolate.GetNameOfDrink();

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
