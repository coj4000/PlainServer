using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class Car
    {
        public string model { get; set; }
        public string color { get; set; }
        public string registrationnr { get; set; }
        public override string ToString()
        {
            return $"modellen er {model}, farven er {color} og registration nr er {registrationnr}";
        }

    }
}
