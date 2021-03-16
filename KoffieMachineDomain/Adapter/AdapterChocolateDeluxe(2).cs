using System;
using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Adapters
{
    public class AdapterChocolateDeluxe : AdapterChocolate
    {
        public AdapterChocolateDeluxe() : base()
        {
            _hotChocolate.MakeDeluxe();
            this.BasePrice = _hotChocolate.Cost();
            this.BaseName = _hotChocolate.GetNameOfDrink();
        }

    }
}
