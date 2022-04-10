using System;
using System.Collections.Generic;

namespace ТЗ
{
    internal class Application
    {
        // Запуск приложения
        public static void Start()
        {
            List<Figure> figures = new List<Figure>();
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.WriteLine("Выберите добавляемую фигуру: 1 - треугольник, 2 - квадрат, 3 - прямоугольник, 4 - окружность, 5 - многоугольник \n" +
                        "Элементы управления: 0 - выход из программы, 6 - вывести список всех фигур и их параметров, 7 - очистить консоль\n" +
                        "8 - считать с файла, 9 - сохранить в файл:");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.NumPad1:
                            figures.Add(Triangle.Input());
                            break;
                        case ConsoleKey.NumPad2:
                            figures.Add(Quad.Input());
                            break;
                        case ConsoleKey.NumPad3:
                            figures.Add(Rectangle.Input());
                            break;
                        case ConsoleKey.NumPad4:
                            figures.Add(Circle.Input());
                            break;
                        case ConsoleKey.NumPad5:
                            figures.Add(Polygon.Input());
                            break;
                        case ConsoleKey.NumPad0:
                            flag = false;
                            break;
                        case ConsoleKey.NumPad6:
                            Output_figures(figures);
                            break;
                        case ConsoleKey.NumPad7:
                            Console.Clear();
                            break;
                        case ConsoleKey.NumPad8:
                            figures = FileHandling.ReadFile();
                            break;
                        case ConsoleKey.NumPad9:
                            FileHandling.WriteFile(figures);
                            break;
                        default:
                            Console.WriteLine("Команды с таким индексом не существует. Выберите команду заново.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка. " + ex.Message);
                }
            }    
        }
        public static void Output_figures (List<Figure> figures)
        {
            Console.WriteLine();
            if (figures.Count() != 0)
            {
                foreach (var figure in figures)
                {
                    Console.WriteLine(figure.ToString());
                }
            }
            else
                Console.WriteLine("Вы еще не добавили ни одной фигуры. ");
        }

    }
}
