using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        private Random _random;
        public int _numberHit;
        public int _multiplier;
        public bool _isBullseye;

        public Dart(Random random)
        {
            _random = random;
        }

        public void Throw()
        {
            /* Set the number being hit to a random number 0-20 
             * If # is zero, it hit inner circle, check if bullseye
             */
            _numberHit = _random.Next(0, 21);
            if(_numberHit == 0) isBullseye();
            if(_numberHit != 0) setMultiplier();


        }

        private void isBullseye()
        {
            /* There is a 5% chance that a dart that hits the inner circle
             * is a bullseye. If # is zero, it is a bullseye
             */
            if (_random.Next(0, 21) == 0) _isBullseye = true;
            else _isBullseye = false;
        }

        private void setMultiplier()
        {
            /* Dart has 1/20 chance to hit a double
             * or triple multipler.  If # is 0, multiplier is triple
             * else if # is 1, multiplier is 2
             */
            int chanceOfMultiplier = _random.Next(0, 21);
            if (chanceOfMultiplier == 0) _multiplier = 3;
            else if (chanceOfMultiplier == 1) _multiplier = 2;
            else _multiplier = 1;
            
        }


    }
}
