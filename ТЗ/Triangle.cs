namespace ТЗ
{
    public class Triangle : IFigure
    {
        public string Title { get; set; } = "Треугольник";
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }


        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        public Triangle() : base()
        {

        }
        public override string ToString()
        {
            return $"{Title} со сторонами {A}, {B}, {C}. Периметр - {P()}, площадь - {S()}";
        }
        public double P()
        {
            return A+B+C;
        }
        public double S()
        {
            var p = 0.5 * P();
            return Math.Sqrt((p * (p - A) * (p - B) - (p - C)));
        }
        /// <summary>
        /// Считывает данные из файла
        /// </summary>
        /// <param name="reader"> 
        /// Объект класса BinaryReader, содержащий путь к файлу и методы для чтения данных из файла
        /// </param>
        /// 
        /// <returns>
        /// Возвращает считанный объект класса Triangle
        /// </returns>
        public static Triangle Read(BinaryReader reader)
        {
            var side_A = reader.ReadDouble();
            var side_B = reader.ReadDouble();
            var side_C = reader.ReadDouble();
            return new Triangle(side_A, side_B, side_C);
        }
        /// <summary>
        /// Записыь данных в бинарный файл
        /// </summary>
        /// <param name="writer">
        /// Объект класса BinaryWriter, содержащий путь к файлу и методы для записи данных в файл
        /// </param>
        public void Write(BinaryWriter writer)
        {
            writer.Write(this.A);
            writer.Write(this.B);
            writer.Write(this.C);
        }
        public static Triangle Input()
        {
            bool flag = true;
            Triangle triangle1 = new Triangle();
            while (flag)
            {
                Console.Write("\nВведите сторону A: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Введите сторону B: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("Введите сторону C: ");
                double c = double.Parse(Console.ReadLine());
                if (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a)
                {
                    triangle1 = new Triangle(a, b, c);
                    flag = false;
                }
                else
                    Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
            }
            return triangle1;
        }
    }
}
