namespace ТЗ
{
    internal class Point
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
        public static double Perimeter_by_points(List<Point> points)
        {
            double p = 0;
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count - 1; i++)
                {
                    p += points[i].Distance(points[i + 1]);
                }
                p += points[points.Count - 1].Distance(points[0]);
            }
            return p;
        }

        public static double Square_by_points(List<Point> points)
        {
            double s=0;
            if (points.Count > 0)
            {
                points[points.Count-1].X = points[0].X;
                points[points.Count-1].Y= points[0].Y;
                for (int i = 1; i <= points.Count-1; i++)
                {
                    s += (points[i - 1].X * points[i].Y - points[i - 1].Y * points[i].X);
                }
            }
            return Math.Abs(s/2);
        }
    }
}
