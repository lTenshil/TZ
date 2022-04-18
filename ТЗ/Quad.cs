namespace ТЗ
{
    public class Quad: IFigure
    {
        public double A { get; set; }
        public string Title { get; set; } = "Квадрат";

        public Quad(double a) => A = a;
        public Quad() { }
        public override string ToString()
        {
            return $"{Title} со сторонами {A}. Периметр - {P()}, площадь - {S()}";
        }
        public  double P()
        { return A * 4; }
        public  double S() { return Math.Pow(A,2); }
        /// <summary>
        /// Чтение данных из бинарного файла
        /// </summary>
        /// <param name="reader"> 
        /// Объект класса BinaryReader, содержащий путь к файлу и методы для чтения данных из файла
        /// </param>
        /// <returns>
        /// Возвращает считанный объект класса Quad
        /// </returns>
        public static Quad Read(BinaryReader reader)
        {
            var side = reader.ReadDouble();
            return  new Quad(side);
        }
        /// <summary>
        /// Запись данных в бинарный файл
        /// </summary>
        /// <param name="writer">
        /// Объект класса BinaryWriter, содержащий путь к файлу и методы для записи данных в файл
        /// </param>
        public void Write(BinaryWriter writer)
        {
            writer.Write(this.A);
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
            return new Quad(a);
        }
    }
}
