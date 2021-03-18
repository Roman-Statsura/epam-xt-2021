using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Hero:Character
    {
        private bool alive;
        public Hero(int x,int y,string name)
        {
            PositionX = x;
            PositionY = y;
            Icon = 'H';
            alive = true;
            Name = name;
            Health = 20;
            Damage = 8;
        }
        public void TurnLeft() 
        {
            --PositionY;
        }

        public void TurnRight() 
        {
            ++PositionY;
        }

        public void TurnUp() 
        {
            --PositionX;
        }

        public void TurnDown()
        {
            ++PositionX;
        }
        public bool IsAlive() => alive;
        public void CheckStep(List<BaseComponent> persons)
        {
            for (int i = 0; i < persons.Count(); i++)
            {
                if (persons[i].PositionX == PositionX && persons[i].PositionY == PositionY)
                {
                    if (persons[i] is Bonus bonus)
                    {
                        Health += bonus.HelthBooster;
                        persons.Remove(bonus);
                        Console.WriteLine($"Бонус {bonus.Name} активирован");
                    }

                    else if (persons[i] is Barrier barrier)
                    {
                        Health += barrier.HealthReducer;
                        persons.Remove(barrier);
                        Console.WriteLine($"Препядствие {barrier.Name} оказалось у вас на пути");
                    }
                    else if (persons[i] is Enemy enemy)
                    {
                        if ((Health/enemy.Damage)<(enemy.Health/Damage))
                        {
                            Health -= enemy.Damage;
                            Console.WriteLine($"Зверь {enemy.Name} делал с вами жуткие вещи!");
                        }
                        else
                        {
                            Health -= enemy.Damage;
                            persons.Remove(enemy);
                            Console.WriteLine($"Противник {enemy.Name} повержен!");
                        }
                    }
                }
            }
        }
    }
}
