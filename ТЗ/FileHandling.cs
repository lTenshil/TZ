namespace ТЗ
{
    public class FileHandling
    {
        // Чтение данных из бинарного файла
        public static List<IFigure> ReadFile ()
        {
            Console.WriteLine("\nВведите путь к файлу: ");
            string str = Console.ReadLine();
            List<IFigure> figures = new List<IFigure>();
            using (FileStream file = new FileStream(@str, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(file))
            {
                while (reader.PeekChar() > -1)
                {
                    string title = reader.ReadString();
                    switch (title)
                    {
                        case "Треугольник":
                            figures.Add(Triangle.Read(reader));
                            break;

                        case "Квадрат":
                            figures.Add(Quad.Read(reader));
                            break;

                        case "Прямоугольник":
                            figures.Add(Rectangle.Read(reader));
                            break;

                        case "Окружность":
                            figures.Add(Circle.Read(reader));
                            break;

                        case "Многоугольник":
                            
                            figures.Add(Polygon.Read(reader));
                            break;
                    }
                }
                Console.WriteLine("Фигуры добавлены из файла.");
            }
            return figures;
        }
        // Запись данных в бинарный файл
        public static void WriteFile(List<IFigure> figures)
        {
            if (figures.Count() > 0)
            {
                Console.WriteLine("\nВведите путь к файлу: ");
                string path = Console.ReadLine();
                using (FileStream file = new FileStream(@path, FileMode.OpenOrCreate))
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    foreach (IFigure figure in figures)
                    {
                        writer.Write(figure.Title);
                        switch (figure.Title)
                        {
                            case "Треугольник":
                                figure.Write(writer);
                                break;

                            case "Квадрат":
                                figure.Write(writer);
                                break;

                            case "Прямоугольник":
                                figure.Write(writer);
                                break;

                            case "Окружность":
                                figure.Write(writer);
                                break;

                            case "Многоугольник":
                                figure.Write(writer);
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
