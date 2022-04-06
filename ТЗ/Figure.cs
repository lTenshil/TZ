namespace ТЗ
{
    internal class Figure
    {
        public string Title { get; set; } = "";
        public Figure (string title) => Title = title;
        public Figure() { }

        
        public override string ToString()
        {
            return $"Фигура - {Title}, Периметр - {GetPerimeter()} Площадь - {GetSquare()}";
        }

        public virtual double GetPerimeter() { return 0; }
        public virtual double GetSquare() { return 0; }
        
    }
}
