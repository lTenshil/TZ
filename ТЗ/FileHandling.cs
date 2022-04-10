namespace ТЗ
{
    internal class FileHandling
    {
        // Чтение данных из бинарного файла
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
        // Запись данных в бинарный файл
        public static void WriteFile(List<Figure> figures)
        {
            if (figures.Count() > 0)
            {
                Console.WriteLine("\nВведите путь к файлу: ");
                string path = Console.ReadLine();
                using (FileStream file = new FileStream(@path, FileMode.Open))
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    foreach (Figure figure in figures)
                    {
                        writer.Write(figure.Title);
                        switch (figure.Title)
                        {
                            case "Треугольник":
                                Triangle.Write(file, figure);
                                break;

                            case "Квадрат":
                                Quad.Write(file, figure);
                                break;

                            case "Прямоугольник":
                                Rectangle.Write(file, figure);
                                break;

                            case "Окружность":
                                Circle.Write(file, figure);
                                break;

                            case "Многоугольник":
                                Polygon.Write(file, figure);
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
