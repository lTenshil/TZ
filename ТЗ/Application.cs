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
            List<Triangle> triangles = new List<Triangle>();
            List<Quad> quads = new List<Quad>();
            List<Rectangle> rectangles = new List<Rectangle>();
            List<Circle> circles = new List<Circle>();
            List<Polygon> polygons = new List<Polygon>();
            List<Figure> figures = new List<Figure>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите добавляемую фигуру: 1 - треугольник, 2 - квадрат, 3 - прямоугольник, 4 - окружность, 5 - многоугольник \n" +
                    "Элементы управления: 0 - выход из программы, 6 - вывести список всех фигур и их параметров, 7 - очистить консоль\n" +
                    "8 - считать с файла, 9 - сохранить в файл:");
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
                            flag = false;
                        break;

                    case 8:
                        Console.WriteLine("Введите путь к файлам с фигурами: ");
                        str = Console.ReadLine();
                        triangles = JsonSerializer.Deserialize<List<Triangle>>(File.ReadAllText(str + "\\Triangles.json"));
                        quads = JsonSerializer.Deserialize<List<Quad>>(File.ReadAllText(str + "\\Quads.json"));
                        rectangles = JsonSerializer.Deserialize<List<Rectangle>>(File.ReadAllText(str + "\\Rectangles.json"));
                        circles = JsonSerializer.Deserialize<List<Circle>>(File.ReadAllText(str + "\\Circles.json"));
                        polygons = JsonSerializer.Deserialize<List<Polygon>>(File.ReadAllText(str + "\\Polygons.json"));
                        figures.AddRange(triangles);
                        figures.AddRange(quads);
                        figures.AddRange(rectangles);
                        figures.AddRange(circles);
                        figures.AddRange(polygons);
                        break;
                    
                    case 9:
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
                            using (FileStream fs = new FileStream(str + "\\Triangles.json", FileMode.OpenOrCreate))
                            {
                                JsonSerializer.SerializeAsync(fs, triangles);

                            }
                            using (FileStream fs = new FileStream(str + "\\Quads.json", FileMode.OpenOrCreate))
                            {
                                JsonSerializer.SerializeAsync(fs, quads);

                            }
                            using (FileStream fs = new FileStream(str + "\\Rectangles.json", FileMode.OpenOrCreate))
                            {
                                JsonSerializer.SerializeAsync(fs, rectangles);

                            }
                            using (FileStream fs = new FileStream(str + "\\Circles.json", FileMode.OpenOrCreate))
                            {
                                JsonSerializer.SerializeAsync(fs, circles);

                            }
                            using (FileStream fs = new FileStream(str + "\\Polygons.json", FileMode.OpenOrCreate))
                            {
                                JsonSerializer.SerializeAsync(fs, polygons);

                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Ошибка. " + e.Message);
                        }
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
