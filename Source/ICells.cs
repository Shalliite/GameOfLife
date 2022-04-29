namespace GameOfLife.Source
{
    public interface ICells
    {
        bool[,] CellArray { get; }
        uint Generation { get; set; }
        ushort LiveCellCount { get; }

        void CalculateNextIteration(ushort sleepTime);
        void SetCellsAlive(bool isAlive, int column, int row);
        void SetCellsRandomAlive();
        void Spawn1Neighbour();
        void Spawn2Neighbours();
        void Spawn3Neighbours();
        void SpawnGlider();
    }
}