namespace ТЗ
{
    public class Rectangle: IFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public string Title { get; set; } = "Прямоугольник";

        public Rectangle(double a, double b)
        {
            A = a;
            B = b;
        }
        public Rectangle() : base() { }
        public override string ToString()
        {
            return $"{Title} со сторонами {A}, {B}. Периметр - {P()}, площадь - {S()}";
        }
        public double P()
        {
            return (A + B) * 2;
        }
        public double S()
        {
            return A*B;
        }
        /// <summary>
        /// Чтение данных из бинарного файла
        /// <param name="reader"> 
        /// Объект класса BinaryReader, содержащий путь к файлу и методы для чтения данных из файла
        /// </param>
        /// <returns>
        /// Возвращает считанный объект класса Rectangle
        /// </returns>
        public static Rectangle Read(BinaryReader reader)
        {
            var A = reader.ReadDouble();
            var B = reader.ReadDouble();
            return new Rectangle(A, B); 
        }
        /// <summary>
        /// Запись объекта в бинарный файл
        /// </summary>
        /// <param name="writer">
        /// Объект класса BinaryWriter, содержащий путь к файлу и методы для записи данных в файл
        /// </param>
        public void Write(BinaryWriter writer)
        {
            writer.Write(this.A);
            writer.Write(this.B);
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
                    rectangle1 = new Rectangle(a,b);
                    flag = false;
                }
                else
                    Console.WriteLine("Внесены некорректные данные, внесите данные заново.");
            }
            return rectangle1;
        }
    }
}
