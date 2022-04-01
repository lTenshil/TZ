namespace ТЗ
{
    internal class Program
    {
        public static void Main()
        {
            List<Figure> figures = new List<Figure>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите добавляемую фигуру: 1 - треугольник, 2 - квадрат, 3 - прямоугольник, 4 - окружность. \n" +
                    "Элементы управления: 0 - выход из программы, 5 - вывести список всех фигур и их параметров, 6 - очистить консоль");
                try
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            Triangle triangle = new Triangle("Треугольник");
                            Triangle.Input(out triangle);
                            figures.Add(triangle);
                            break;

                        case 2:
                            Quad quad = new Quad("");
                            Quad.Input(out quad);
                            figures.Add(quad);
                            break;

                        case 3:
                            Rectangle rectangle = new Rectangle("");
                            Rectangle.Input(out rectangle);
                            figures.Add(rectangle);
                            break;

                        case 4:
                            Circle circle = new Circle("");
                            Circle.Input(out circle);
                            figures.Add(circle);
                            break;

                        case 0:
                            flag = false;
                            break;

                        case 5:
                            if (figures.Count() != 0)
                            {
                                foreach (var fig in figures)
                                {
                                    fig.GetPerimetr();
                                    fig.GetSquare();
                                    fig.Print();
                                }
                            }
                            else
                                Console.WriteLine("Вы еще не добавили ни одной фигуры. ");
                            break;

                        case 6:
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Команды с таким индексом не существует. Выберите команду заново.");
                            break;
                    }

                }
                catch (Exception ex)
                { Console.WriteLine($"Ошибка: {ex.Message}"); }
            }
        }

    }
}