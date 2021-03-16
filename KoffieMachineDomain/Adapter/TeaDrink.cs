using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Adapters
{
    public class TeaDrink : Drink
    {
        protected TeaAndChocoLibrary.Tea _tea;


        public TeaBlend teaBlend
        {
            get { return _tea.Blend; }
            set { _tea.Blend = value; }
        }

        public TeaDrink() : base()
        {
            _tea = new TeaAndChocoLibrary.Tea();
            BasePrice = TeaAndChocoLibrary.Tea.Price;
            BaseName = "Tea";

        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {_tea.Blend.Name}," + " which has an " + $"{_tea.Blend.BagColor.Name}" + " color.");
            log.Add($"Heating up...");

        }
    }
}
