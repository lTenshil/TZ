namespace ТЗ
{
    public interface IFigure
    {
        string Title { get; set; }
        double P();
        double S();
        void Write(BinaryWriter writter);
    }
}
