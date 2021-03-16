using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> figuresName = new List<string>() { "1.Линия", "2.Треугольник", "3.Квадрат", "4.Прямоугольник",
                "5.Окружность", "6.Круг", "7.Кольцо" };
            Dictionary<string, User> users = new Dictionary<string, User>();
            Console.WriteLine("Введите имя и создайте пользователя:");
            string userName = Console.ReadLine();
            User user = new User(userName);
            users.Add(userName, user);
            User activeUser = user;
            while (true)
            {
                Console.WriteLine($"{activeUser.GetName()}, Выберите действие:" + Environment.NewLine + "1.Добавить фигуру" + Environment.NewLine +
                    "2.Вывести фигуры" + Environment.NewLine + "3.Очистить холст" + Environment.NewLine + "4.Выход" + Environment.NewLine +
                    "5.Сменить пользователя" + Environment.NewLine);
                int t = Convert.ToInt32(Console.ReadLine());
                switch (t)
                {
                    case 1:
                        Console.WriteLine($"{activeUser.GetName()}, Выберите тип фигуры:");
                        foreach (var item in figuresName)
                        {
                            Console.WriteLine(item);
                        }
                        int f = Convert.ToInt32(Console.ReadLine());
                        switch (f)
                        {
                            case 1:
                                Console.WriteLine($"{activeUser.GetName()}, Введите параметры линии:");
                                Console.WriteLine("Введите длину:");
                                int lineA = Convert.ToInt32(Console.ReadLine());
                                Line line = new Line(lineA);
                                line.SuccessfullyCreated();
                                activeUser.AddToCanvas(line);
                                break;
                            case 2:
                                Console.WriteLine($"{activeUser.GetName()}, Введите параметры фигуры треугольник:");
                                Console.WriteLine("Введите сторону A:");
                                int trA = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите сторону B:");
                                int trB = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите сторону C:");
                                int trC = Convert.ToInt32(Console.ReadLine());
                                Triangle triangle = new Triangle(trA, trB, trC);
                                triangle.SuccessfullyCreated();
                                activeUser.AddToCanvas(triangle);
                                break;
                            case 3:
                                Console.WriteLine($"{activeUser.GetName()}, Введите параметры фигуры квадрат:");
                                Console.WriteLine("Введите сторону:");
                                int sqA = Convert.ToInt32(Console.ReadLine());
                                Square square = new Square(sqA);
                                square.SuccessfullyCreated();
                                activeUser.AddToCanvas(square);
                                break;
                            case 4:
                                Console.WriteLine($"{activeUser.GetName()}, Введите параметры фигуры прямоугльник:");
                                Console.WriteLine("Введите сторону A:");
                                int reA = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите сторону B:");
                                int reB = Convert.ToInt32(Console.ReadLine());
                                Rectangle rectangle = new Rectangle(reA, reB);
                                rectangle.SuccessfullyCreated();
                                activeUser.AddToCanvas(rectangle);
                                break;
                            case 5:
                                Console.WriteLine($"{activeUser.GetName()}, Введите параметры фигуры окружность:");
                                Console.WriteLine("Введите координыт центра:");
                                Console.WriteLine("A: ");
                                int cA = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("B: ");
                                int cB = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите радиус:");
                                int cR = Convert.ToInt32(Console.ReadLine());
                                Circle circle = new Circle(cA, cB, cR);
                                circle.SuccessfullyCreated();
                                activeUser.AddToCanvas(circle);
                                break;
                            case 6:
                                Console.WriteLine($"{activeUser.GetName()}, Введите параметры фигуры круг:");
                                Console.WriteLine("Введите координыт центра:");
                                Console.WriteLine("A: ");
                                int rA = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("B: ");
                                int rB = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите радиус:");
                                int rR = Convert.ToInt32(Console.ReadLine());
                                Round round = new Round(rA, rB, rR);
                                round.SuccessfullyCreated();
                                activeUser.AddToCanvas(round);
                                break;
                            case 7:
                                Console.WriteLine($"{activeUser.GetName()}, Введите параметры фигуры кольцо:");
                                Console.WriteLine("Введите координыт центра:");
                                Console.WriteLine("A: ");
                                int ringA = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("B: ");
                                int ringB = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите внутренний радиус:");
                                int ringInR = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите внешний радиус:");
                                int ringOutR = Convert.ToInt32(Console.ReadLine());
                                Ring ring = new Ring(ringA, ringB, ringInR, ringOutR);
                                ring.SuccessfullyCreated();
                                activeUser.AddToCanvas(ring);
                                break;
                        }
                        break;
                    case 2:
                        if (activeUser.GetCanvas().Count() == 0)
                        {
                            Console.WriteLine("В наличии фигур нет");
                        }
                        else
                        {
                            Console.WriteLine("В наличии фигуры:");
                            foreach (var item in activeUser.GetCanvas())
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case 3:
                        activeUser.ClearCanvas();
                        break;
                    case 4:
                        return;
                    case 5:
                        Console.WriteLine("1.Создать нового пользователя");
                        Console.WriteLine("2.Выбрать существующего");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine("Введите новое имя:");
                                string newName = Console.ReadLine();
                                User newUser = new User(newName);
                                users.Add(newName, newUser);
                                activeUser = newUser;
                                break;
                            case 2:
                                Console.WriteLine("Выберите пользователя:");
                                string s = string.Join(", ", users.Keys);
                                Console.WriteLine(s);
                                string target = Console.ReadLine();  
                                if (!users.ContainsKey(target))
                                {
                                    Console.WriteLine("Нет такого пользователя");
                                    break;
                                }
                                else
                                {
                                    activeUser = users[target];
                                    break;
                                }
                        }
                        break;
                }
            }
        }
    }
}
