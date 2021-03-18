using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class AppleBonus:Bonus
    {
        public AppleBonus()
        {
            CreateLocation();
            Icon = 'я';
            Name = "Яблоко";
            HelthBooster = 10;
        }
    }
}
