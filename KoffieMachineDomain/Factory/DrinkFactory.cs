using KoffieMachineDomain.Adapters;
using KoffieMachineDomain.Decorator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Factory
{
    public class DrinkFactory
    {
        public IEnumerable<string> TeaBlendNames => _teaBlendRepository.BlendNames;
        private readonly TeaBlendRepository _teaBlendRepository;
        private readonly Dictionary<string, IDrink> _drinks;

        public DrinkFactory()
        {
            _teaBlendRepository = new TeaBlendRepository();
            _drinks = new Dictionary<string, IDrink>();
            _drinks["Coffee"] = new Coffee();
            _drinks["Café au Lait"] = new CafeAuLait();
            _drinks["Chocolate"] = new Chocolate(false);
            _drinks["Chocolate Deluxe"] = new Chocolate(true);
            _drinks["Tea"] = new TeaDrink();
            IDrink espresso = new Espresso();
            espresso = new DrinkAmountDecorator(espresso, Amount.Few);
            espresso = new StrengthDecorator(espresso, Strength.Strong);
            _drinks["Espresso"] = espresso;
            IDrink capuccino = new Espresso();
            capuccino = new Capuccino();
            capuccino = new StrengthDecorator(capuccino, Strength.Normal);
            _drinks["Capuccino"] = capuccino;
            IDrink wienerMelange = new WienerMelange();
            wienerMelange = new StrengthDecorator(wienerMelange, Strength.Weak);
            _drinks["Wiener Melange"] = wienerMelange;
        }


        public IDrink ProduceDrink(string drinkName, ICollection<string> logText, Amount milkAmount, Amount sugarAmount, Strength coffeeStrength, string teaBlendName)
        {
            List<string> split = new List<string>(drinkName.Split('-'));
            IDrink selectedDrink = SelectDrink(split[0], teaBlendName);
            if (selectedDrink == null)
            {
                logText.Add($"Could not make {drinkName}, recipe not found.");
            }
            else
            {
                foreach (var extras in split)
                {
                    switch (extras)
                    {
                        case "milk":
                            selectedDrink = new MilkDecorator(selectedDrink, milkAmount);
                            break;
                        case "sugar":
                            selectedDrink = new SugarDecorator(selectedDrink, sugarAmount);
                            break;
                        case "strength":
                            selectedDrink = new StrengthDecorator(selectedDrink, coffeeStrength);
                            break;
                    }
                }

                logText.Add($"Selected {selectedDrink.GetName()}, price: {selectedDrink.GetPrice().ToString("C", CultureInfo.CurrentCulture)}");
            }

            return selectedDrink;
        }

        private IDrink SelectDrink(string name, string teaBlendName)
        {
            IDrink selectedDrink = null;

            if (name.Equals("Tea"))
            {
                selectedDrink = new TeaDrink()
                {
                    teaBlend = _teaBlendRepository.GetTeaBlend(teaBlendName)
                };
            }
            else
            {
                if (_drinks.Keys.Contains(name))
                {
                    selectedDrink = _drinks[name];
                }
                else
                {
                    selectedDrink = null;
                }
            }
            return selectedDrink;
        }
    }
}