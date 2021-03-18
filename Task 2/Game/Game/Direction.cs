using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Direction
    {
        public static int  RIGHT = 0;    
        public static int DOWN = 1;    
        public static int LEFT = 2;
        public static int UP = 3;
        public int state;
        public void ChangeToRight()            
        {
            if (state != LEFT)
                state = RIGHT;
        }

        public void ChangeToDown()            
        {
            if (state != UP)
                state = DOWN;
        }

        public void ChangeToLeft()           
        {
            if (state != RIGHT)
                state = LEFT;
        }

        public void ChangeToUp()            
        {
            if (state != DOWN)
                state = UP;
        }
    }
}
