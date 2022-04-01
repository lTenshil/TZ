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

        public override void Print()
        {
            Console.WriteLine($"{Title} со сторонами {Side}. Периметр - {Perimeter}, площадь - {Square}");
        }
        public override void GetPerimetr()
        {
            Perimeter = Math.Round(Side * 4,2);
        }
        public override void GetSquare()
        {
            Square = Math.Round(Math.Pow(Side,2), 2);
        }
        public static void Input(out Quad quad)
        {
            
            bool flag = true;
            Quad quad1 = new Quad("");
            while (flag)
            {
                Console.Write("Введите длину сторон квадрата: ");
                double a = Convert.ToDouble(Console.ReadLine());
                if (a > 0)
                {
                    quad1 = new Quad("Квадрат", a);
                    flag = false;
                }
                else
                    Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
            }
            quad = quad1;
        }
    }
}
