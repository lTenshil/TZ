namespace ТЗ
{
    internal class Triangle : Figure
    {
        
        public double Side_A { get; set; }
        public double Side_B { get; set; }
        public double Side_C { get; set; }

        public Triangle(string title,double side_A, double side_B, double side_C): base(title)
        {
            Side_A = side_A;
            Side_B = side_B;
            Side_C = side_C;
        }

        public Triangle(string title): base(title)
        {

        }

        public override void Print()
        {
            Console.WriteLine($"{Title} со сторонами {Side_A}, {Side_B}, {Side_C}. Периметр - {Perimeter}, площадь - {Square}");
        }
        public override void GetPerimetr()
        {
            Perimeter = Math.Round(Side_A+Side_B+Side_C,2);
        }
        public override void GetSquare()
        {   
            var p = 0.5 * Perimeter;
            Square = Math.Round(Math.Sqrt((p * (p - Side_A) * (p - Side_B) - (p - Side_C))),2);
        }

        public static void Input(out Triangle triangle)
        {
                bool flag = true;
            Triangle triangle1 = new Triangle("Треугольник");
                while (flag)
                {
                    Console.Write("Введите сторону A: ");
                    double a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите сторону B: ");
                    double b = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите сторону C: ");
                    double c = Convert.ToDouble(Console.ReadLine());
                    if (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a)
                    {
                        triangle1 = new Triangle("Треугольник", a, b, c);
                        flag = false;
                    }
                    else
                        Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
                }
            triangle = triangle1;
        }
    }
}
