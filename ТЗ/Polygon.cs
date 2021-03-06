namespace ТЗ
{
    public class Polygon: IFigure
    {
        public List<Point> Vertices { get; set; }
        public string Title { get; set; } = "Многоугольник";

        public Polygon(string title,List<Point>? vertices)
        {
            Vertices = vertices;
        }
        public Polygon( ) : base() { }
        /// <summary>
        /// Чтение данных из бинарного файла
        /// <param name="reader"> 
        /// Объект класса BinaryReader, содержащий путь к файлу и методы для чтения данных из файла
        /// </param>
        /// <returns>
        /// Возвращает считанный объект класса Polygon
        /// </returns>
        public static Polygon Read(BinaryReader reader)
        {
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
        /// <param name="writer">
        /// Объект класса BinaryWriter, содержащий путь к файлу и методы для записи данных в файл
        /// </param>
        public void Write(BinaryWriter writer)
        {
            writer.Write(this.Vertices.Count());
            foreach (Point side in this.Vertices)
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
            s += $"Периметр: {P()}, площадь - {S()}";
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
        public double Area_by_points()
        {
            double s = 0;
            if (this.Vertices.Count > 0)
            {
                this.Vertices[Vertices.Count - 1].X = Vertices[0].X;
                this.Vertices[Vertices.Count - 1].Y = Vertices[0].Y;
                for (int i = 1; i <= Vertices.Count - 1; i++)
                {
                    s += (Vertices[i - 1].X * Vertices[i].Y - Vertices[i - 1].Y * Vertices[i].X);
                }
            }
            return Math.Abs(s / 2);
        }
        public double P()
        {
            return Perimeter_by_points(Vertices);
        }
        public double S()
        {
            return Area_by_points();
        }
    }
}
