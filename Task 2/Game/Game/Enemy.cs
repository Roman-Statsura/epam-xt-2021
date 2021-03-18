using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public abstract class Enemy:Character
    {
        public void CatchHero(int x,int y, List<BaseComponent> objectOnTheField)
        {
            int differenceX = x - PositionX;
            int differenceY = y - PositionY;

            if (Math.Abs(differenceX) >= Math.Abs(differenceY))
            {
                if (differenceX > 0) // Down
                {
                    bool stepPossibility = true;
                    for (int i = 0; i < objectOnTheField.Count; i++)
                    {
                        if (objectOnTheField[i].PositionY == PositionY && (objectOnTheField[i].PositionX - PositionX) == 1)
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
                    for (int i = 0; i < objectOnTheField.Count; i++)
                    {
                        if (objectOnTheField[i].PositionY == PositionY && (objectOnTheField[i].PositionX - PositionX) == -1)
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
                    for (int i = 0; i < objectOnTheField.Count; i++)
                    {
                        if (objectOnTheField[i].PositionX == PositionX && (objectOnTheField[i].PositionY - PositionY) == 1)
                        {
                            stepPossibility = false;
                            if (PositionX == (Canvas.HEIGHT - 1)) --PositionX;
                            else if (PositionX == 0) ++PositionX;
                            else if (x == PositionX) --PositionX;
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
                    for (int i = 0; i < objectOnTheField.Count; i++)
                    {
                        if (objectOnTheField[i].PositionX == PositionX && (objectOnTheField[i].PositionY - PositionY) == -1)
                        {
                            stepPossibility = false;
                            if (PositionX == (Canvas.HEIGHT - 1)) --PositionX;
                            else if (PositionX == 0) ++PositionX;
                            else if (x == PositionX) --PositionX;
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
