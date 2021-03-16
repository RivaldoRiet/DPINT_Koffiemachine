using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Adapters
{
    public class AdapterTeaDrink : Drink
    {
        protected TeaAndChocoLibrary.Tea _tea;


        public TeaBlend teaBlend
        {
            get { return _tea.Blend; }
            set { _tea.Blend = value; }
        }

        public AdapterTeaDrink() : base()
        {
            _tea = new TeaAndChocoLibrary.Tea();
            BasePrice = TeaAndChocoLibrary.Tea.Price;
            BaseName = "Tea";

        }


        public override void LogDrinkMaking(ICollection<string> logText)
        {
            base.LogDrinkMaking(logText);
            logText.Add("Filling with hot water...");
            logText.Add($"Putting {_tea.Blend.BagColor.Name} tea bag, {_tea.Blend.Name} in cup...");

        }



    }
}
