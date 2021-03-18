using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class CherryBonus:Bonus
    {
        public CherryBonus()
        {
            CreateLocation();
            Icon = 'в';
            Name = "Вишня";
            HelthBooster = 10;
        }
    }
}
