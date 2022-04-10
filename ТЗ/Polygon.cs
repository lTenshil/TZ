namespace ТЗ
{
    internal class Polygon: Figure
    {
        public List<Point> ? Vertices { get; set; } 
        public Polygon(string title,List<Point>? vertices): base(title)
        {
            Vertices = vertices;
        }
        public Polygon( ) : base() { }
        /// <summary>
        /// Чтение данных из бинарного файла
        /// </summary>
        /// <param name="file">
        /// Объект класса FileStream, содержащий путь к файлу и его режим открытия
        /// </param>
        /// <param name="position">
        /// Позиция в файле, начиная с которой необходимо начать чтение
        /// </param>
        /// <returns>
        /// Возвращает считанный объект класса Polygon
        /// </returns>
        public static Polygon Read(FileStream file, long position)
        {
            BinaryReader reader = new BinaryReader(file);
            reader.BaseStream.Position = position;
            int n1 = reader.ReadInt32();
            List<Point> sides = new List<Point>();
            for (int i = 0; i < n1; i++)
            {
                double X = reader.ReadDouble();
                double Y = reader.ReadDouble();
                sides.Add(new Point(X, Y));
            }
            return new Polygon("Многоугольник", sides);
        }
        /// <summary>
        /// Записыь данных в бинарный файл
        /// </summary>
        /// <param name="file">
        /// Объект класса FileStream, содержащий путь к файлу для записи и режим доступа к файлу
        /// </param>
        /// <param name="figure">
        /// Объект типа Figure, который необходимо записать в файл
        /// </param>
        public static void Write(FileStream file, Figure figure)
        {
            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(((Polygon)figure).Vertices.Count());
            foreach (Point side in ((Polygon)figure).Vertices)
            {
                writer.Write(side.X);
                writer.Write(side.Y);
            }
        }
        public override string ToString()
        {
            string s = $"{Title} с координатами: ";
            if (Vertices != null)
            {
                for (int i = 0; i < Vertices.Count; i++)
                {
                    if (i == Vertices.Count() - 1)
                        s += $"({Vertices[i].X}, {Vertices[i].Y}). ";
                    else
                        s += $"({Vertices[i].X}, {Vertices[i].Y}), ";
                }

            }
            else
                Console.WriteLine("Вершины не заданы");
            s += $"Периметр: {GetPerimeter()}, площадь - {GetArea()}";
            return s.ToString();
        }

        public static Polygon Input ()
        {
            List<Point> vertices = new List<Point>();
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.Write("\nВведите количество вершин многоугольника: ");
                    int n = int.Parse(Console.ReadLine());
                    if (n > 3)
                    {
                        for (int i = 0; i<n; i++)
                        {
                            Console.Write($"Введите координату X вершины {i + 1}: ");
                            double x = double.Parse(Console.ReadLine());
                            Console.Write($"Введите координату Y вершины {i + 1}: ");
                            double y = double.Parse(Console.ReadLine());
                            var obj = new Point(x, y);
                            vertices.Add(obj);
                        }
                        flag = false;
                    }
                    else
                        Console.WriteLine("Многоугольник не может содержать меньше 4 вершин.");
                }
                catch (Exception ex)
                { Console.WriteLine($"Ошибка: {ex.Message}"); }
            }
            return new Polygon("Многоугольник", vertices);
        }
        /// <summary>
        /// Получение периметра многоугольника по координатам вершин
        /// </summary>
        /// <param name="points">
        /// Координаты вершин многоугольника
        /// </param>
        /// <returns></returns>
        public double Perimeter_by_points(List<Point> points)
        {
            double p = 0;
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count - 1; i++)
                {
                    p += points[i].Distance(points[i + 1]);
                }
                p += points[points.Count - 1].Distance(points[0]);
            }
            return p;
        }
        /// <summary>
        /// Получение площади многоугольника по координатам вершин
        /// </summary>
        /// <param name="points">
        /// Координаты вершин многоугольника
        /// </param>
        /// <returns></returns>
        public double Area_by_points(List<Point> points)
        {
            double s = 0;
            if (points.Count > 0)
            {
                points[points.Count - 1].X = points[0].X;
                points[points.Count - 1].Y = points[0].Y;
                for (int i = 1; i <= points.Count - 1; i++)
                {
                    s += (points[i - 1].X * points[i].Y - points[i - 1].Y * points[i].X);
                }
            }
            return Math.Abs(s / 2);
        }
        public override double GetPerimeter()
        {
            return Math.Round(Perimeter_by_points(Vertices),2);
        }
        public override double GetArea()
        {
            return Math.Round(Area_by_points(Vertices),2);
        }
    }
}
