using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ТЗ
{
    internal class Application
    {
        static string str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\Фигуры\\Triangles.json";

        public static async void  Start()
        {
            List<Triangle> triangles = new List<Triangle>();
            List<Quad> quads = new List<Quad>();
            List<Rectangle> rectangles = new List<Rectangle>();
            List<Circle> circles = new List<Circle>();
            List<Polygon> polygons = new List<Polygon>();
            List<Figure> figures = new List<Figure>();
            triangles = JsonSerializer.Deserialize<List<Triangle>>(File.ReadAllText(str));
            str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Фигуры\\Quads.json";
            quads = JsonSerializer.Deserialize<List<Quad>>(File.ReadAllText(str));
            str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Фигуры\\Rectangles.json";
            rectangles = JsonSerializer.Deserialize<List<Rectangle>>(File.ReadAllText(str));
            str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Фигуры\\Circles.json";
            circles = JsonSerializer.Deserialize<List<Circle>>(File.ReadAllText(str));
            str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Фигуры\\Polygons.json";
            polygons = JsonSerializer.Deserialize<List<Polygon>>(File.ReadAllText(str));
            figures.AddRange(triangles);
            figures.AddRange(quads);
            figures.AddRange(rectangles);
            figures.AddRange(circles);
            figures.AddRange(polygons);
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите добавляемую фигуру: 1 - треугольник, 2 - квадрат, 3 - прямоугольник, 4 - окружность, 5 - многоугольник \n" +
                    "Элементы управления: 0 - выход из программы, 6 - вывести список всех фигур и их параметров, 7 - очистить консоль:");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Triangle triangle = new Triangle("Треугольник");
                        Triangle.Input(out triangle);
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
                        if (figures.Count() != 0)
                        {
                            try
                            {
                                var list = figures.Distinct().ToList();
                                foreach (var fig in list)
                                {
                                    fig.GetPerimetr();
                                    fig.GetSquare();
                                    if (fig.Title == "Треугольник")
                                        triangles.Add((Triangle)fig);
                                    if (fig.Title == "Квадрат")
                                        quads.Add((Quad)fig);
                                    if (fig.Title == "Прямоугольник")
                                        rectangles.Add((Rectangle)fig);
                                    if (fig.Title == "Окружность")
                                        circles.Add((Circle)fig);
                                    if (fig.Title == "Многоугольник")
                                        polygons.Add((Polygon)fig);
                                }
                                triangles = triangles.Distinct().ToList();
                                quads = quads.Distinct().ToList();
                                rectangles = rectangles.Distinct().ToList();
                                circles = circles.Distinct().ToList();
                                polygons = polygons.Distinct().ToList();
                                string strT = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Фигуры\\Triangles.json";
                                using (FileStream fs = new FileStream(strT, FileMode.OpenOrCreate))
                                {
                                    JsonSerializer.SerializeAsync(fs,triangles);
                                
                                }
                                string strQ = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Фигуры\\Quads.json";
                                using (FileStream fs = new FileStream(strQ, FileMode.OpenOrCreate))
                                {
                                    JsonSerializer.SerializeAsync(fs, quads);

                                }
                                string strR = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Фигуры\\Rectangles.json";
                                using (FileStream fs = new FileStream(strR, FileMode.OpenOrCreate))
                                {
                                    JsonSerializer.SerializeAsync(fs, rectangles);

                                }
                                string strC = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Фигуры\\Circles.json";
                                using (FileStream fs = new FileStream(strC, FileMode.OpenOrCreate))
                                {
                                    JsonSerializer.SerializeAsync(fs, circles);

                                }
                                string strP = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Фигуры\\Polygons.json";
                                using (FileStream fs = new FileStream(strP, FileMode.OpenOrCreate))
                                {
                                    JsonSerializer.SerializeAsync(fs, polygons);

                                }
                                flag = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка. " + e.Message);
                            }
                        }
                        else
                            flag = false;
                        break;

                    case 6:
                        if (figures.Count() != 0)
                        {
                            for (int i = 0; i < figures.Count(); i++)
                            {
                                figures[i].Print();
                            }
                        }
                        else
                            Console.WriteLine("Вы еще не добавили ни одной фигуры. ");
                        break;

                    case 7:
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Команды с таким индексом не существует. Выберите команду заново.");
                        break;
                }
            }
        }
    }
}
