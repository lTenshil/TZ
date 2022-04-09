namespace ТЗ
{
    internal class Quad: Figure
    {
        public double Side { get; set; }

        public Quad(string title,double side) : base(title)
        {
            Side = side;
        }

        public Quad(string title) : base(title)
        {
        }
        public Quad() : base()
        {
        }
        public override string ToString()
        {
            return $"{Title} со сторонами {Side}. Периметр - {GetPerimeter()}, площадь - {GetSquare()}";
        }

        public override double GetPerimeter()
        {
            return Math.Round(Side * 4,2);
        }
        public override double GetSquare()
        {
            return Math.Round(Math.Pow(Side,2), 2);
        }
        
        public static Quad Input()
        {
            
            bool flag = true;
            Console.Write("\nВведите длину сторон квадрата: ");
            double a = double.Parse(Console.ReadLine());
            if (a > 0)
            {
                flag = false;
            }
            else
                Console.WriteLine("Внесены некорректные данные, внесите данные заново.");

            return new Quad("Квадрат", a);
        }
    }
}
