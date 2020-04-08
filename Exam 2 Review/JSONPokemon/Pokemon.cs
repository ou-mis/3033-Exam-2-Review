using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONPokemon
{
    class Pokemon
    {
        public int height { get; set; }
        public int weight { get; set; }
        public string name { get; set; }

        //public SOMETHING forms { get; set; }

        public override string ToString()
        {
            return $"{name} is {height} inches tall and weighs {weight} pounds.";
        }
    }
}
