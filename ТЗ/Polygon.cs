namespace ТЗ
{
    internal class Polygon: Figure
    {
        public List<Point> ? Vertices { get; set; }

        public Polygon(string title,List<Point>? vertices): base(title)
        {
            Vertices = vertices;
        }

        public Polygon(string title): base(title)
        {

        }
        public Polygon( ) : base()
        {
           
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
            s += $"Периметр: {GetPerimeter()}, площадь - {GetSquare()}";
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
                    Console.Write("Введите количество вершин многоугольника: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n > 3)
                    {
                        for (int i = 0; i<n; i++)
                        {
                            Console.Write($"Введите координату X вершины {i + 1}: ");
                            double x = Convert.ToDouble(Console.ReadLine());
                            Console.Write($"Введите координату Y вершины {i + 1}: ");
                            double y = Convert.ToDouble(Console.ReadLine());
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

        public double Square_by_points(List<Point> points)
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
        public override double GetSquare()
        {
            return Math.Round(Square_by_points(Vertices),2);
        }
    }
}
