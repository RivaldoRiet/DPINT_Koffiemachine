using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class CafeAuLait : Drink
    {
        public CafeAuLait() : base()
        {
            this.BasePrice += 0.5;
            this.BaseName = "Café au Lait";
        }


        public override void LogDrinkMaking(ICollection<string> logText)
        {

            base.LogDrinkMaking(logText);

            logText.Add("Filling half with coffee...");
            logText.Add("Filling other half with milk...");
        }

    }
}

