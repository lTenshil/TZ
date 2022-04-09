namespace ТЗ
{
    internal class Circle: Figure
    {
        public double Radius { get; set; }

        public Circle(string title,double radius): base(title)
        {
            Radius = radius;
        }

        public Circle(string title): base(title)
        {
        }
        public Circle() : base()
        {
        }
        public override string ToString()
        {
            return $"{Title} со радиусом {Radius}. Периметр - {GetPerimeter()}, площадь - {GetSquare()}";
        }
        public override double GetPerimeter()
        {
            return Math.Round(2 * Math.PI * Radius,2);
        }
        public override double GetSquare()
        {
            return Math.Round(Math.PI * Math.Pow(Radius,2),2);
        }
        public static Circle Read(FileStream file, long position)
        {
            var circle = new Circle();
            BinaryReader reader = new BinaryReader(file);
            reader.BaseStream.Position = position;
            var radius = reader.ReadDouble();
            circle = new Circle("Треугольник", radius);
            return circle;
        }
        public static void Write(FileStream file, Figure figure)
        {
            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(((Circle)figure).Radius);
        }
        public static Circle Input()
        {
            bool flag = true;
            Circle circle1 = new Circle("");
            while (flag)
            {
                Console.Write("\nВведите радиус: ");
                double a = double.Parse(Console.ReadLine());
                if (a > 0)
                {
                    circle1 = new Circle("Окружность", a);
                    flag = false;
                }
                else
                    Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
            }
            return circle1;
        }
    }
}
