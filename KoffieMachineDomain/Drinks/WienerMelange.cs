using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class WienerMelange : Capuccino
    {

        public WienerMelange() : base()
        {
            this.BasePrice *= 2;
            this.BaseName = "Wiener Melange";
        }


    }
}
