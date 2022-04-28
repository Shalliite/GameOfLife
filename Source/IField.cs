namespace GameOfLife.Source
{
    public interface IField
    {
        void Render(Cells cells);
        void UpdateDimensions(ushort width, ushort height);
    }
}