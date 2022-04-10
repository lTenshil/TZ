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
        public Triangle() : base()
        {

        }
        public override string ToString()
        {
            return $"{Title} со сторонами {Side_A}, {Side_B}, {Side_C}. Периметр - {GetPerimeter()}, площадь - {GetArea()}";
        }
        public override double GetPerimeter()
        {
            return Math.Round(Side_A+Side_B+Side_C,2);
        }
        public override double GetArea()
        {
            var p = 0.5 * GetPerimeter();
            return Math.Round(Math.Sqrt((p * (p - Side_A) * (p - Side_B) - (p - Side_C))),2);
        }
        /// <summary>
        /// Считывает данные из файла
        /// </summary>
        /// <param name="file"> 
        /// Объект класса FileStream, содержащий путь к файлу и его режим открытия
        /// </param>
        /// <param name="position">
        /// Позиция в файле, начиная с которой необходимо начать чтение
        /// </param>
        /// <returns>
        /// Возвращает считанный объект класса Triangle
        /// </returns>
        public static Triangle Read(FileStream file,long position)
        {
            var triangle = new Triangle();
            BinaryReader reader = new BinaryReader(file);
            reader.BaseStream.Position = position;
            var side_A = reader.ReadDouble();
            var side_B = reader.ReadDouble();
            var side_C = reader.ReadDouble();
            return new Triangle("Треугольник", side_A, side_B, side_C);
        }
        /// <summary>
        /// Записыь данных в бинарный файл
        /// </summary>
        /// <param name="file">
        /// Объект класса FileStream, содержащий путь к файлу для записи и режим доступа к файлу
        /// </param>
        /// <param name="figure">
        /// Объект класса Figure, который необходимо записать в файл
        /// </param>
        public static void Write(FileStream file, Figure figure)
        {
            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(((Triangle)figure).Side_A);
            writer.Write(((Triangle)figure).Side_B);
            writer.Write(((Triangle)figure).Side_C);
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
                    triangle1 = new Triangle("Треугольник", a, b, c);
                    flag = false;
                }
                else
                    Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
            }
            return triangle1;
        }

    }
}
