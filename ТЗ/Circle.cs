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
        public static void Input(out Circle circle)
        {
            bool flag = true;
            Circle circle1 = new Circle("");
            while (flag)
            {
                Console.Write("Введите радиус: ");
                double a = Convert.ToDouble(Console.ReadLine());
                if (a > 0)
                {
                    circle1 = new Circle("Окружность", a);
                    flag = false;
                }
                else
                    Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
            }
            circle = circle1;
        }
    }
}
