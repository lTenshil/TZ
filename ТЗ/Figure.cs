namespace ТЗ
{
    internal class Figure
    {
        public string Title { get; set; } = "";
        public double Perimeter { get; set; }
        public double Square { get; set; }
        public Figure (string title) => Title = title;
        
        public virtual void Print()
        {
            Console.WriteLine($"Фигура - {Title}");
        }
        public virtual void GetPerimetr() { }
        public virtual void GetSquare() { }
        
    }
}
