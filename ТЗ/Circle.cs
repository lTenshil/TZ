namespace ТЗ
{
    public class Circle: IFigure
    {
        public double R { get; set; }
        public string Title { get; set; } = "Окружность";
        public Circle(double radius) => (R) = (radius);
        public Circle() { }
        public override string ToString()
        {
            return $"{Title} со радиусом {R}. Периметр - {P()}, площадь - {S()}";
        }
        public double P() { return 2 * Math.PI * R;}
        public double S() { return Math.PI * Math.Pow(R,2); }
        /// <summary>
        /// Чтение данных из бинарного файла
        /// </summary>
        /// <param name="reader"> 
        /// Объект класса BinaryReader, содержащий путь к файлу и методы для чтения данных из файла
        /// </param>
        /// <returns>
        /// Возвращает считанный объект класса Circle
        /// </returns>
        public static Circle Read(BinaryReader reader)
        {
            var radius = reader.ReadDouble();
            return  new Circle(radius);
        }
        /// <summary>
        /// Запись данных в бинарный файл
        /// </summary>
        /// <param name="writer">
        /// Объект класса BinaryWriter, содержащий путь к файлу и методы для записи данных в файл
        /// </param>
        public void Write(BinaryWriter writer)
        {
            writer.Write(this.R);
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
                    circle1 = new Circle(a);
                    flag = false;
                }
                else
                    throw new Exception("Радиус не может быть отрицательным");
            }
            return circle1;
        }
    }
}
