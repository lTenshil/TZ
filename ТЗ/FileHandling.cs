namespace ТЗ
{
    internal class FileHandling
    {
        public static List<Figure> ReadFile ()
        {
            Console.WriteLine("\nВведите путь к файлу: ");
            string str = Console.ReadLine();
            List<Figure> figures = new List<Figure>();
            using (FileStream file = new FileStream(@str, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(file))
            {
                while (reader.PeekChar() > -1)
                {
                    string title = reader.ReadString();
                    switch (title)
                    {
                        case "Треугольник":
                            figures.Add(Triangle.Read(file, reader.BaseStream.Position));
                            break;

                        case "Квадрат":
                            figures.Add(Quad.Read(file, reader.BaseStream.Position));
                            break;

                        case "Прямоугольник":
                            figures.Add(Rectangle.Read(file, reader.BaseStream.Position));
                            break;

                        case "Окружность":
                            figures.Add(Circle.Read(file, reader.BaseStream.Position));
                            break;

                        case "Многоугольник":
                            
                            figures.Add(Polygon.Read(file, reader.BaseStream.Position));
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
