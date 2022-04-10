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
        public Rectangle() : base() { }
        public override string ToString()
        {
            return $"{Title} со сторонами {Side_A}, {Side_B}. Периметр - {GetPerimeter()}, площадь - {GetArea()}";
        }
        public override double GetPerimeter()
        {
            return Math.Round((Side_A + Side_B) * 2,2);
        }
        public override double GetArea()
        {
            return Math.Round(Side_A*Side_B,2);
        }
        /// <summary>
        /// Чтение данных из бинарного файла
        /// </summary>
        /// <param name="file">
        /// Объект класса FileStream, содержащий путь к файлу и его режим открытия
        /// </param>
        /// <param name="position">
        /// Позиция в файле, начиная с которой необходимо начать чтение
        /// </param>
        /// <returns>
        /// Возвращает считанный объект класса Rectangle
        /// </returns>
        public static Rectangle Read(FileStream file, long position)
        {
            BinaryReader reader = new BinaryReader(file);
            reader.BaseStream.Position = position;
            var side_A = reader.ReadDouble();
            var side_B = reader.ReadDouble();
            return new Rectangle("Прямоугольник", side_A, side_B); 
        }
        /// <summary>
        /// Запись объекта в бинарный файл
        /// </summary>
        /// <param name="file">
        /// Объект класса FileStream, содержащий путь к файлу для записи и режим доступа к файлу
        /// </param>
        /// <param name="figure">
        /// Объект класса Figure, который необходимо записать в бинарный файл
        /// </param>
        public static void Write(FileStream file, Figure figure)
        {
            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(((Rectangle)figure).Side_A);
            writer.Write(((Rectangle)figure).Side_A);
        }
        public static Rectangle Input()
        {
            bool flag = true;
            Rectangle rectangle1 = new Rectangle();
            while (flag)
            {
                Console.Write("\nВведите сторону A: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Введите сторону B: ");
                double b = double.Parse(Console.ReadLine());
                if (a > 0 && b>0 && a!=b)
                {
                    rectangle1 = new Rectangle("Прямоугольник", a,b);
                    flag = false;
                }
                else
                    Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
            }
            return rectangle1;
        }
    }
}
