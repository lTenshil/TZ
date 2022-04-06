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

        public static void Input (out Polygon polygon)
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
            polygon = new Polygon("Многоугольник", vertices);
        }
        public override double GetPerimeter()
        {
            return Math.Round(Point.Perimeter_by_points(Vertices),2);
        }
        public override double GetSquare()
        {
            return Math.Round(Point.Square_by_points(Vertices),2);
        }
    }
}
