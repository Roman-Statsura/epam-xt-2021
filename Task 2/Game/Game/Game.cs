using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Game
{
    public class Game
    {
        private List<BaseComponent> objectOnTheField = new List<BaseComponent>();
        public void StartNewGame()
        {
            Console.WriteLine("Добро пожаловать в игру!");
            Console.WriteLine("Введите имя героя:");
            string nameOfHero = Console.ReadLine();
            Hero hero = new Hero(0, 0, nameOfHero);
            Description();
            Console.WriteLine($"{hero.Name}, Приготовьтесь! Игра начинается!"); 
            Canvas canvas = new Canvas();
            AppleBonus appleBonus = new AppleBonus();
            CherryBonus cherryBonus = new CherryBonus();
            objectOnTheField.Add(cherryBonus);
            objectOnTheField.Add(appleBonus);
            Rock rock = new Rock();
            Three three = new Three();
            Grenade grenade = new Grenade();
            objectOnTheField.Add(rock);
            objectOnTheField.Add(three);
            objectOnTheField.Add(grenade);
            MadRabbit madRabbit = new MadRabbit();
            Wolf wolf = new Wolf();
            objectOnTheField.Add(wolf);
            objectOnTheField.Add(madRabbit);
            Coin c1 = new Coin();
            Coin c2 = new Coin();
            Coin c3 = new Coin();
            objectOnTheField.Add(c1);
            objectOnTheField.Add(c2);
            objectOnTheField.Add(c3);
            while (true)
            {
                if (!CheckHealth(hero)) return;
                Canvas.Field[hero.PositionX, hero.PositionY] = hero.Icon;
                foreach (var item in objectOnTheField)
                {
                    Canvas.Field[item.PositionX, item.PositionY] = item.Icon;
                }
                canvas.PrintCanvas();
                if (!CheckCollectedCoins()) return;
                Console.WriteLine(Environment.NewLine + "XP: "+hero.Health);
                Console.WriteLine("Прыжков во времени: "+hero.JumpInTime+Environment.NewLine);
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Q:
                        if (hero.JumpInTime > 0)
                        {
                            ConsoleKeyInfo key1 = Console.ReadKey(true);
                            switch (key1.Key)
                            {
                                case ConsoleKey.UpArrow:
                                    hero.RemoveTheTrail(Canvas.Field);
                                    hero.TurnUp(2);
                                    hero.JumpInTime -= 1;
                                    hero.CheckStep(objectOnTheField);
                                    break;
                                case ConsoleKey.DownArrow:
                                    hero.RemoveTheTrail(Canvas.Field);
                                    hero.TurnDown(2);
                                    hero.JumpInTime -= 1;
                                    hero.CheckStep(objectOnTheField);
                                    break;
                                case ConsoleKey.RightArrow:
                                    hero.RemoveTheTrail(Canvas.Field);
                                    hero.TurnRight(2);
                                    hero.JumpInTime -= 1;
                                    hero.CheckStep(objectOnTheField);
                                    break;
                                case ConsoleKey.LeftArrow:
                                    hero.RemoveTheTrail(Canvas.Field);
                                    hero.TurnLeft(2);
                                    hero.JumpInTime -= 1;
                                    hero.CheckStep(objectOnTheField);
                                    break;
                            }
                        }
                        else Console.WriteLine("Нет возможности прыгнуть во времени(");
                        break;
                    case ConsoleKey.RightArrow:
                        hero.RemoveTheTrail(Canvas.Field);
                        hero.TurnRight();
                        hero.CheckStep(objectOnTheField);
                        foreach (var item in objectOnTheField)
                        {
                            if (item is Enemy enemy)
                            {
                                enemy.RemoveTheTrail(Canvas.Field);
                                enemy.CatchHero(hero.PositionX, hero.PositionY, objectOnTheField);
                            }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        hero.RemoveTheTrail(Canvas.Field);
                        hero.TurnLeft();
                        hero.CheckStep(objectOnTheField);
                        foreach (var item in objectOnTheField)
                        {
                            if (item is Enemy enemy)
                            {
                                enemy.RemoveTheTrail(Canvas.Field);
                                enemy.CatchHero(hero.PositionX, hero.PositionY, objectOnTheField);
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        hero.RemoveTheTrail(Canvas.Field);
                        hero.TurnUp();
                        hero.CheckStep(objectOnTheField);
                        foreach (var item in objectOnTheField)
                        {
                            if (item is Enemy enemy)
                            {
                                enemy.RemoveTheTrail(Canvas.Field);
                                enemy.CatchHero(hero.PositionX, hero.PositionY, objectOnTheField);
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        hero.RemoveTheTrail(Canvas.Field);
                        hero.TurnDown();
                        hero.CheckStep(objectOnTheField);
                        foreach (var item in objectOnTheField)
                        {
                            if (item is Enemy enemy)
                            {
                                enemy.RemoveTheTrail(Canvas.Field);
                                enemy.CatchHero(hero.PositionX, hero.PositionY, objectOnTheField);
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
        private bool CheckCollectedCoins()
        {
            int countActiveBonuses = (from item in objectOnTheField
                                      where item is Coin
                                      select item).Count();
            if (countActiveBonuses == 0)
            {
                Console.WriteLine("Вы победили!");
                return false;
            }
            return true;
        }
        private void Description()
        {
            Console.WriteLine("Правила игры:");
            Console.WriteLine("Вы играете за героя - 'H'");
            Console.WriteLine("Нужно собрать все монеты - '$'");
            Console.WriteLine("Остерегайтесь диких зверей, они могут покусать или даже убить, с ними можно драться,если сил хватает");
            Console.WriteLine("Вот их представители: Дикий Заяц - '*' и Волк - '?'");
            Console.WriteLine("Монжно собирать бонусы: 'в' и 'я' - увеличивают XP");
            Console.WriteLine("На пути так же встречаются препядствия: 'д'- дерево, 'к'- камень. Они отнимают XP");
            Console.WriteLine("Берегись гранаты '@' - она убивает сразу!");
            Console.WriteLine();
            Console.WriteLine("Управление: Герой управляется стрелками на клавиатуре" + Environment.NewLine);
            Console.WriteLine("Вы можете осуществить прыжок во времени нажава 'Q'+ стрелочку, куда хотите прыгнуть");
            Console.WriteLine("При прыжке время останавливается и вы перемещаетесь на две клеточки"+Environment.NewLine);
        }
    }
}
