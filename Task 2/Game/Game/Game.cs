using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Game
{
    public class Game
    {
        private List<BaseComponent> persons = new List<BaseComponent>();
        public void StartNewGame()
        {
            Console.WriteLine("Добро пожаловать в игру!");
            Console.WriteLine("Введите имя героя:");
            string nameOfHero = Console.ReadLine();
            Hero hero = new Hero(0, 0, nameOfHero);
            Console.WriteLine($"{hero.Name}, Приготовьтесь! Игра начианется!");
            Console.WriteLine("Правила: w - Вверх; d - Вправо; s - Вниз; a - Влево" + Environment.NewLine);
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
                if (!CheckHealth(hero)) return;
                Canvas.Field[hero.PositionX, hero.PositionY] = hero.Icon;
                foreach (var item in persons)
                {
                    Canvas.Field[item.PositionX, item.PositionY] = item.Icon;
                }
                canvas.PrintCanvas();
                if (!CheckCollectedBonuses()) return;
                Console.WriteLine(Environment.NewLine + "XP: "+hero.Health);
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
        private bool CheckHealth(Hero hero)
        {
            if (hero.Health <= 0)
            {
                Console.WriteLine("Вы проиграли(");
                return false;
            }
            return true;
        }
        private bool CheckCollectedBonuses()
        {
            int countActiveBonuses = (from item in persons
                                      where item is Bonus
                                      select item).Count();
            if (countActiveBonuses == 0)
            {
                Console.WriteLine("Вы победили!");
                return false;
            }
            return true;
        }
    }
}
