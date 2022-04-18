namespace ТЗ
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double Distance(Point point)
        {
            double distance = Math.Abs((point.X-X) * (point.X-X) - (point.Y-Y) * (point.Y - Y));
            return Math.Sqrt(distance);
        }
        
    }
}
