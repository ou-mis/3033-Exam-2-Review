using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONPokemon
{
    class Pokemon
    {
        public List<Abilities> abilities { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string name { get; set; }


        public override string ToString()
        {
            string msg = $"{name} is {height} inches tall and weighs {weight} pounds with {abilities.Count} abilities:";
            foreach (var a in abilities)
            {
                msg += $"\n {a.ability.name}";
            }
            return msg;
        }
    }

    public class Abilities
    {
        public Ability ability { get; set; }
        public bool is_hidden { get; set; }
        public string slot { get; set; }
    }

    public class Ability
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
