using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ТЗ
{
    internal class Application
    {
        static string str;

        public static async void  Start()
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
                    int n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            Triangle triangle = Triangle.Input();
                            figures.Add(triangle);
                            break;

                        case 2:
                            Quad quad = new Quad("");
                            Quad.Input(out quad);
                            figures.Add(quad);
                            break;

                        case 3:
                            Rectangle rectangle = new Rectangle("");
                            Rectangle.Input(out rectangle);
                            figures.Add(rectangle);
                            break;

                        case 4:
                            Circle circle = new Circle("");
                            Circle.Input(out circle);
                            figures.Add(circle);
                            break;

                        case 5:
                            Polygon polygon = new Polygon("");
                            Polygon.Input(out polygon);
                            figures.Add(polygon);
                            break;

                        case 0:
                            flag = false;
                            break;

                        case 6:
                            if (figures.Count() != 0)
                            {
                                for (int i = 0; i < figures.Count(); i++)
                                {
                                    Console.WriteLine(figures[i].ToString());
                                }
                            }
                            else
                                Console.WriteLine("Вы еще не добавили ни одной фигуры. ");
                            break;

                        case 7:
                            Console.Clear();
                            break;

                        case 8:
                            Console.WriteLine("Введите путь к файлу: ");
                            str = Console.ReadLine();
                            using (BinaryReader reader = new BinaryReader(File.Open(str, FileMode.Open)))
                            {
                                while (reader.PeekChar() > -1)
                                {
                                    string title = reader.ReadString();
                                    if (title == "Треугольник")
                                    {
                                        double a = reader.ReadDouble();
                                        double b = reader.ReadDouble();
                                        double c = reader.ReadDouble();
                                        figures.Add(new Triangle(title, a, b, c));
                                    }
                                    else if (title == "Квадрат")
                                    {
                                        double a = reader.ReadDouble();
                                        figures.Add(new Quad(title, a));
                                    }
                                    else if (title == "Прямоугольник")
                                    {
                                        double a = reader.ReadDouble();
                                        double b = reader.ReadDouble();
                                        figures.Add(new Rectangle(title, a, b));
                                    }
                                    else if (title == "Окружность")
                                    {
                                        double r = reader.ReadDouble();
                                        figures.Add(new Circle(title, r));
                                    }
                                    else if (title == "Многоугольник")
                                    {
                                        int n1 = reader.ReadInt32();
                                        List<Point> sides = new List<Point>();
                                        for (int i = 0; i < n1; i++)
                                        {
                                            double X = reader.ReadDouble();
                                            double Y = reader.ReadDouble();
                                            sides.Add(new Point(X, Y));
                                        }
                                        figures.Add(new Polygon(title, sides));
                                    }
                                }
                                Console.WriteLine("Фигуры добавлены из файла.");
                            }
                            break;

                        case 9:
                            Console.WriteLine("Введите путь к файлу: ");
                            str = Console.ReadLine();
                            using (BinaryWriter writer = new BinaryWriter(File.Open(str, FileMode.OpenOrCreate)))
                            {
                                foreach (Figure figure in figures)
                                {
                                    if (figure.Title == "Треугольник")
                                    {
                                        writer.Write(figure.Title);
                                        writer.Write(((Triangle)figure).Side_A);
                                        writer.Write(((Triangle)figure).Side_B);
                                        writer.Write(((Triangle)figure).Side_C);
                                    }
                                    else if (figure.Title == "Квадрат")
                                    {
                                        writer.Write(figure.Title);
                                        writer.Write(((Quad)figure).Side);
                                    }
                                    else if (figure.Title == "Прямоугольник")
                                    {
                                        writer.Write(figure.Title);
                                        writer.Write(((Rectangle)figure).Side_A);
                                        writer.Write(((Rectangle)figure).Side_B);
                                    }
                                    else if (figure.Title == "Окружность")
                                    {
                                        writer.Write(figure.Title);
                                        writer.Write(((Circle)figure).Radius);
                                    }
                                    else if (figure.Title == "Многоугольник")
                                    {
                                        writer.Write(figure.Title);
                                        writer.Write(((Polygon)figure).Vertices.Count());
                                        foreach (Point side in ((Polygon)figure).Vertices)
                                        {
                                            writer.Write(side.X);
                                            writer.Write(side.Y);
                                        }
                                    }
                                }
                                Console.WriteLine("Файл успешно сохранен.");
                            }
                            break;

                        default:
                            Console.WriteLine("Команды с таким индексом не существует. Выберите команду заново.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка" + ex.Message);
                }
            }
        
            
        }
    }
}
