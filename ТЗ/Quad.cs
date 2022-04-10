namespace ТЗ
{
    internal class Quad: Figure
    {
        public double Side { get; set; }
        public Quad(string title,double side) : base(title) { Side = side; }
        public Quad() : base() { }
        public override string ToString()
        {
            return $"{Title} со сторонами {Side}. Периметр - {GetPerimeter()}, площадь - {GetArea()}";
        }
        public override double GetPerimeter()
        {
            return Math.Round(Side * 4,2);
        }
        public override double GetArea()
        {
            return Math.Round(Math.Pow(Side,2), 2);
        }
        /// <summary>
        /// Чтение данных из бинарного файла
        /// </summary>
        /// <param name="file">
        /// Объект класса FileStream, содержащий путь к файлу и его режим открытия
        /// </param>
        /// <param name="position">
        /// Позиция в файле, с которой начинается чтение
        /// </param>
        /// <returns>
        /// Возвращает считанный объект класса Quad
        /// </returns>
        public static Quad Read(FileStream file, long position)
        {
            BinaryReader reader = new BinaryReader(file);
            reader.BaseStream.Position = position;
            var side = reader.ReadDouble();
            return  new Quad("Квадрат", side);
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
            writer.Write(((Quad)figure).Side);
        }
        public static Quad Input()
        {
            bool flag = true;
            Console.Write("\nВведите длину сторон квадрата: ");
            double a = double.Parse(Console.ReadLine());
            if (a > 0)
                flag = false;
            else
                Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
            return new Quad("Квадрат", a);
        }
    }
}
