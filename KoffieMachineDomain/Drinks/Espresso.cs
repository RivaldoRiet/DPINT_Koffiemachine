using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Espresso : Drink
    {
        public Espresso() : base()
        {

            this.BasePrice += 0.7;
            this.BaseName = "Espresso";
        }

        public override void LogDrinkMaking(ICollection<string> logText)
        {
            base.LogDrinkMaking(logText);

            logText.Add("Filling with coffee...");

            logText.Add("Creaming milk...");
            logText.Add("Adding milk to coffee...");
        }
    }
}

