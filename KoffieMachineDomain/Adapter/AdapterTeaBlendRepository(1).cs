using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Adapters
{
    public class AdapterTeaBlendRepository
    {

        private TeaAndChocoLibrary.TeaBlendRepository _teaBlendRepository;

        public IEnumerable<string> BlendNames
        {
            get { return _teaBlendRepository.BlendNames; }
        }
        public AdapterTeaBlendRepository()
        {

            _teaBlendRepository = new TeaAndChocoLibrary.TeaBlendRepository();

        }
        public TeaBlend GetTeaBlend(string name)
        {
            return _teaBlendRepository.GetTeaBlend(name);
        }
    }
}
