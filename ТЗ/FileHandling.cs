namespace ТЗ
{
    internal class FileHandling
    {
        public static List<Figure> ReadFile ()
        {
            Console.WriteLine("\nВведите путь к файлу: ");
            string str = Console.ReadLine();
            List<Figure> figures = new List<Figure>();
            using (BinaryReader reader = new BinaryReader(File.Open(@str, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string title = reader.ReadString();
                    switch (title)
                    {
                        case "Треугольник":
                            double a = reader.ReadDouble();
                            double b = reader.ReadDouble();
                            double c = reader.ReadDouble();
                            figures.Add(new Triangle(title, a, b, c));
                            break;

                        case "Квадрат":
                            double d = reader.ReadDouble();
                            figures.Add(new Quad(title, d));
                            break;

                        case "Прямоугольник":
                            double e = reader.ReadDouble();
                            double f = reader.ReadDouble();
                            figures.Add(new Rectangle(title, e,f));
                            break;

                        case "Окружность":
                            double g = reader.ReadDouble();
                            figures.Add(new Circle(title, g));
                            break;

                        case "Многоугольник":
                            int n1 = reader.ReadInt32();
                            List<Point> sides = new List<Point>();
                            for (int i = 0; i < n1; i++)
                            {
                                double X = reader.ReadDouble();
                                double Y = reader.ReadDouble();
                                sides.Add(new Point(X, Y));
                            }
                            figures.Add(new Polygon(title, sides));
                            break;
                    }
                }
                Console.WriteLine("Фигуры добавлены из файла.");
            }
            return figures;
        }
        public static void WriteFile(List<Figure> figures)
        {
            if (figures.Count() > 0)
            {
                Console.WriteLine("\nВведите путь к файлу: ");
                string path = Console.ReadLine();
                using (BinaryWriter writer = new BinaryWriter(File.Open(@path, FileMode.OpenOrCreate)))
                {
                    foreach (Figure figure in figures)
                    {
                        writer.Write(figure.Title);
                        switch (figure.Title)
                        {
                            case "Треугольник":
                                writer.Write(((Triangle)figure).Side_A);
                                writer.Write(((Triangle)figure).Side_B);
                                writer.Write(((Triangle)figure).Side_C);
                                break;

                            case "Квадрат":
                                writer.Write(((Quad)figure).Side);
                                break;

                            case "Прямоугольник":
                                writer.Write(((Rectangle)figure).Side_A);
                                writer.Write(((Rectangle)figure).Side_B);
                                break;

                            case "Окружность":
                                writer.Write(((Circle)figure).Radius);
                                break;

                            case "Многоугольник":
                                writer.Write(((Polygon)figure).Vertices.Count());
                                foreach (Point side in ((Polygon)figure).Vertices)
                                {
                                    writer.Write(side.X);
                                    writer.Write(side.Y);
                                }
                                break;
                        }
                    }
                    Console.WriteLine("Файл успешно сохранен.");
                }
            }
            else Console.WriteLine("\nВы еще не добавили ни одной фигуры.");
        }

    }
}
