using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy.YatzyGame
{
    internal class Tarning
    {
        private Random random;

        public Tarning()
        {
            random = new Random();
        }

        // Rolls a single six-sided die and returns the result (1 to 6)
        public int Roll()
        {
            return random.Next(1, 7);
        }
    }
}
