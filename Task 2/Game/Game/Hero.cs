using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Hero:Character
    {
        public int JumpInTime { get; set; }
        public Hero(int x,int y,string name)
        {
            PositionX = x;
            PositionY = y;
            Icon = 'H';
            Name = name;
            Health = 20;
            Damage = 8;
            JumpInTime = 5;
        }
        public void TurnLeft() 
        {
            --PositionY;
        }
        public void TurnLeft(int n)
        {
            for (int i = 0; i < n; i++)
            {
                --PositionY;
            }
        }
        public void TurnRight() 
        {
            ++PositionY;
        }
        public void TurnRight(int n)
        {
            for (int i = 0; i < n; i++)
            {
                ++PositionY;
            }
        }
        public void TurnUp() 
        {
            --PositionX;
        }
        public void TurnUp(int n)
        {
            for (int i = 0; i < n; i++)
            {
                --PositionX;
            }
        }
        public void TurnDown()
        {
            ++PositionX;
        }
        public void TurnDown(int n)
        {
            for (int i = 0; i < n; i++)
            {
                ++PositionX;
            }
        }
        public void CheckStep(List<BaseComponent> objectOnTheField)
        {
            for (int i = 0; i < objectOnTheField.Count(); i++)
            {
                if (objectOnTheField[i].PositionX == PositionX && objectOnTheField[i].PositionY == PositionY)
                {
                    if (objectOnTheField[i] is Bonus bonus)
                    {
                        Health += bonus.HelthBooster;
                        objectOnTheField.Remove(bonus);
                        Console.WriteLine($"Бонус {bonus.Name} активирован");
                    }
                    else if (objectOnTheField[i] is Coin coin)
                    {
                        objectOnTheField.Remove(coin);
                        JumpInTime += coin.IncreaseJumpsInTime;
                        Console.WriteLine("Монета собрана!");
                    }
                    else if (objectOnTheField[i] is Barrier barrier)
                    {
                        Health += barrier.HealthReducer;
                        objectOnTheField.Remove(barrier);
                        Console.WriteLine($"Препядствие {barrier.Name} оказалось у вас на пути");
                    }
                    else if (objectOnTheField[i] is Enemy enemy)
                    {
                        if ((Health/enemy.Damage)<(enemy.Health/Damage))
                        {
                            Health -= enemy.Damage;
                            Console.WriteLine($"Зверь {enemy.Name} делал с вами жуткие вещи!");
                        }
                        else
                        {
                            Health -= enemy.Damage;
                            objectOnTheField.Remove(enemy);
                            Console.WriteLine($"Противник {enemy.Name} повержен!");
                        }
                    }
                }
            }
        }
    }
}
