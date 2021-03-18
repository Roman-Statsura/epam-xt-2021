using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public abstract class Enemy:Character
    {
        public void CatchHero(int x,int y, List<BaseComponent> persons)
        {
            int differenceX = x - PositionX;
            int differenceY = y - PositionY;

            if (Math.Abs(differenceX) >= Math.Abs(differenceY))
            {
                if (differenceX > 0) // Down
                {
                    bool stepPossibility = true;
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (persons[i].PositionY == PositionY && (persons[i].PositionX - PositionX) == 1)
                        {
                            stepPossibility = false;
                            if (PositionY == (Canvas.WIDTH - 1)) --PositionY;
                            else if (PositionY == 0) ++PositionY;
                            else if (y == PositionY) --PositionY;
                            else
                            {
                                if (differenceY > 0) ++PositionY;
                                else --PositionY;
                            }
                        }
                    }
                    if (stepPossibility) ++PositionX;
                }
                else  // UP
                {
                    bool stepPossibility = true;
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (persons[i].PositionY == PositionY && (persons[i].PositionX - PositionX) == -1)
                        {
                            stepPossibility = false;
                            if (PositionY == (Canvas.WIDTH - 1)) --PositionY;
                            else if (PositionY == 0) ++PositionY;
                            else if (y == PositionY) --PositionY;
                            else
                            {
                                if (differenceY > 0) ++PositionY;
                                else --PositionY;
                            }
                        }
                    }
                    if (stepPossibility) --PositionX;
                }
            }
            else
            {
                if (differenceY > 0) //Right
                {
                    bool stepPossibility = true;
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (persons[i].PositionX == PositionX && (persons[i].PositionY - PositionY) == 1)
                        {
                            stepPossibility = false;
                            if (PositionY == (Canvas.WIDTH - 1)) --PositionY;
                            else if (PositionY == 0) ++PositionY;
                            else if (y == PositionY) --PositionY;
                            else
                            {
                                if (differenceX > 0) ++PositionX;
                                else --PositionX;
                            }
                        }
                    }
                    if (stepPossibility) ++PositionY;
                }
                else  // Left
                {
                    bool stepPossibility = true;
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (persons[i].PositionX == PositionX && (persons[i].PositionY - PositionY) == -1)
                        {
                            stepPossibility = false;
                            if (PositionY == (Canvas.WIDTH - 1)) --PositionY;
                            else if (PositionY == 0) ++PositionY;
                            else if (y == PositionY) --PositionY;
                            else
                            {
                                if (differenceX > 0) ++PositionX;
                                else --PositionX;
                            }
                        }
                    }
                    if (stepPossibility) --PositionY;
                }
            }
        }
    }
}
