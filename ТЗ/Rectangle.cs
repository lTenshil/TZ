namespace ТЗ
{
    internal class Rectangle: Figure
    {
        public double Side_A { get; set; }
        public double Side_B { get; set; }

        public Rectangle(string title,double side_A, double side_B): base(title)
        {
            Side_A = side_A;
            Side_B = side_B;
        }

        public Rectangle(string title): base(title)
        {
        }

        public override void Print()
        {
            Console.WriteLine($"{Title} со сторонами {Side_A}, {Side_B}. Периметр - {Perimeter}, площадь - {Square}");
        }
        public override void GetPerimetr()
        {
            Perimeter = Math.Round((Side_A + Side_B) * 2,2);
        }
        public override void GetSquare()
        {
            Square = Math.Round(Side_A*Side_B,2);
        }
        public static void Input(out Rectangle rectangle)
        {
            bool flag = true;
            Rectangle rectangle1 = new Rectangle("");
            while (flag)
            {
                Console.Write("Введите сторону A: ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите сторону B: ");
                double b = Convert.ToDouble(Console.ReadLine());
                if (a > 0 && b>0 && a!=b)
                {
                    rectangle1 = new Rectangle("Прямоугольник", a,b);
                    flag = false;
                }
                else
                    Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
            }
            rectangle = rectangle1;
        }
    }
}
