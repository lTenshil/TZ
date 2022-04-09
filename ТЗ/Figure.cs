namespace ТЗ
{
    internal abstract class Figure
    {
        public string Title { get; set; }
        public Figure (string title) => Title = title;
        public Figure() { }
        public override string ToString()
        {
            return $"Фигура - {Title}, Периметр - {GetPerimeter()} Площадь - {GetSquare()}";
        }
        public abstract double GetPerimeter();
        public abstract double GetSquare();
    }
}
