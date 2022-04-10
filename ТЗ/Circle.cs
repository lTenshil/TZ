namespace ТЗ
{
    internal class Circle: Figure
    {
        public double Radius { get; set; }

        public Circle(string title,double radius): base(title) { Radius = radius; }
        public Circle() : base() { }
        public override string ToString()
        {
            return $"{Title} со радиусом {Radius}. Периметр - {GetPerimeter()}, площадь - {GetArea()}";
        }
        public override double GetPerimeter() { return Math.Round(2 * Math.PI * Radius,2);}
        public override double GetArea()
        {
            return Math.Round(Math.PI * Math.Pow(Radius,2),2);
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
        /// Возвращает считанный объект класса Circle
        /// </returns>
        public static Circle Read(FileStream file, long position)
        {
            BinaryReader reader = new BinaryReader(file);
            reader.BaseStream.Position = position;
            var radius = reader.ReadDouble();
            return  new Circle("Окружность", radius);
        }
        /// <summary>
        /// Запись данных в бинарный файл
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
            writer.Write(((Circle)figure).Radius);
        }
        public static Circle Input()
        {
            bool flag = true;
            Circle circle1 = new Circle();
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
