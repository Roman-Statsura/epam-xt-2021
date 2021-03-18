using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseComponent> persons = new List<BaseComponent>();
            Console.WriteLine("Введите имя героя:");
            string nameOfHero = Console.ReadLine();
            Hero hero = new Hero(0, 0,nameOfHero);
            Console.WriteLine($"Добро пожаловать в игру {hero.Name}!");
            Console.WriteLine("w - Вверх; d - Вправо; s - Вниз; a - Влево"+Environment.NewLine);
            Canvas canvas = new Canvas();
            AppleBonus appleBonus = new AppleBonus();
            CherryBonus cherryBonus = new CherryBonus();
            persons.Add(cherryBonus);
            persons.Add(appleBonus);
            Rock rock = new Rock();
            Three three = new Three();
            persons.Add(rock);
            persons.Add(three);
            MadRabbit madRabbit = new MadRabbit();
            Wolf wolf = new Wolf();
            persons.Add(wolf);
            persons.Add(madRabbit);
            while (true)
            {
                if (hero.Health <= 0)
                {
                    Console.WriteLine("Вы проиграли");
                    return;
                }
                int countActiveBonuses = 0;
                foreach (var item in persons)
                {
                    if (item is Bonus)

                        countActiveBonuses++;
                    
                    if (countActiveBonuses == 0)
                    {
                        Console.WriteLine("Вы победили!");
                        return;
                    }
                }
                Canvas.Field[hero.PositionX, hero.PositionY] = hero.Icon;
                foreach (var item in persons)
                {
                    Canvas.Field[item.PositionX, item.PositionY] = item.Icon;
                }
                canvas.PrintCanvas();
                Console.WriteLine(Environment.NewLine + hero.Health);
                string t = Console.ReadLine();
                switch (t)
                {
                    case "d":
                        hero.RemoveTheTrail(Canvas.Field);
                        hero.TurnRight();
                        hero.CheckStep(persons);
                        foreach (var item in persons)
                        {
                            if (item is Enemy enemy)
                            {
                                enemy.RemoveTheTrail(Canvas.Field);
                                enemy.CatchHero(hero.PositionX, hero.PositionY, persons);
                            }
                        }
                        break;
                    case "a":
                        hero.RemoveTheTrail(Canvas.Field);
                        hero.TurnLeft();
                        hero.CheckStep(persons);
                        foreach (var item in persons)
                        {
                            if (item is Enemy enemy)
                            {
                                enemy.RemoveTheTrail(Canvas.Field);
                                enemy.CatchHero(hero.PositionX, hero.PositionY, persons);
                            }
                        }      
                        break;
                    case "w":
                        hero.RemoveTheTrail(Canvas.Field);
                        hero.TurnUp();
                        hero.CheckStep(persons);
                        foreach (var item in persons)
                        {
                            if (item is Enemy enemy)
                            {
                                enemy.RemoveTheTrail(Canvas.Field);
                                enemy.CatchHero(hero.PositionX, hero.PositionY, persons);
                            }
                        }
                        break;
                    case "s":
                        hero.RemoveTheTrail(Canvas.Field);
                        hero.TurnDown();
                        hero.CheckStep(persons);
                        foreach (var item in persons)
                        {
                            if (item is Enemy enemy)
                            {
                                enemy.RemoveTheTrail(Canvas.Field);
                                enemy.CatchHero(hero.PositionX, hero.PositionY, persons);
                            }
                        }
                        break;
                }
            }
        }
        
    }
}
