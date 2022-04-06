namespace ТЗ
{
    internal class Figure
    {
        public string Title { get; set; } = "";
        public double Perimeter { get; set; }
        public double Square { get; set; }
        public Figure (string title) => Title = title;
        public Figure() { }

        public virtual void Print()
        {
            Console.WriteLine($"Фигура - {Title}, Периметр - {Perimeter} Площадь - {Square}");
        }
        
        public virtual void GetPerimetr() { }
        public virtual void GetSquare() { }
        
    }
}
