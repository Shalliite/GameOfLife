namespace GameOfLife.Source
{
    /// <summary>
    /// Class for new cells to be created.
    /// </summary>
    public class Cells
    {
        /// <summary>
        /// Property that stores cells.
        /// </summary>
        public bool[,] CellArray { get { return cells; } }
        private bool[,] cells;

        /// <summary>
        /// Constructs new cell instance.
        /// </summary>
        /// <param name="columnCount">Cell column count.</param>
        /// <param name="rowCount">Cell row count.</param>
        public Cells(ushort columnCount, ushort rowCount)
        {
            cells = new bool[columnCount, rowCount];
        }

        /// <summary>
        /// Function that returns current live cell count.
        /// </summary>
        /// <returns>Current alive cells.</returns>
        private ushort GetCurrentLiveCellCount()
        {
            ushort liveCellCount = 0;
            for (ushort currentRow = 0; currentRow < RowCount; currentRow++)
            {
                for (ushort currentColumn = 0; currentColumn < ColumnCount; currentColumn++)
                {
                    if (cells[currentRow, currentColumn])
                        liveCellCount++;
                }
            }
            return liveCellCount;
        }

        /// <summary>
        /// Function that processes main cell logic.
        /// </summary>
        /// <param name="sleepTime">How fast cells needs to be updated.</param>
        public void CalculateNextIteration(ushort sleepTime)
        {
            bool[,] nextGenerationCells = new bool[cells.GetLength(1), cells.GetLength(0)];
            for (int currentRow = 0; currentRow < cells.GetLength(0); currentRow++)
            {

                for (int currentColumn = 0; currentColumn < cells.GetLength(1); currentColumn++)
                {
                    ushort liveCellCount;

                    int nextRow = currentRow == cells.GetLength(0) - 1 ? 0 : currentRow + 1;
                    int previousRow = currentRow == 0 ? cells.GetLength(0) - 1 : currentRow - 1;
                    int nextColumn = currentColumn == cells.GetLength(1) - 1 ? 0 : currentColumn + 1;
                    int previousColumn = currentColumn == 0 ? cells.GetLength(1) - 1 : currentColumn - 1;

                    //check if there is something arround
                    liveCellCount = cells[previousColumn, currentRow] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[previousColumn, previousRow] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[currentColumn, previousRow] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[nextColumn, previousRow] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[nextColumn, currentRow] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[nextColumn, nextRow] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[currentColumn, nextRow] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[previousColumn, nextRow] ? (ushort)1 : (ushort)0;

                    bool isCurrentCellAlive = false;
                    switch (liveCellCount)
                    {
                        case 3:
                            isCurrentCellAlive = true;
                            break;
                        case 2:
                            if (cells[currentColumn, currentRow])
                            {
                                isCurrentCellAlive = true;
                            }
                            break;
                    }

                    nextGenerationCells[currentColumn, currentRow] = isCurrentCellAlive;
                }
            }
            cells = nextGenerationCells;
            Generation++;
            Thread.Sleep(sleepTime);
        }

        /// <summary>
        /// Function that sets specific cells to be alive or dead.
        /// </summary>
        /// <param name="isAlive">Status to set.</param>
        /// <param name="column">Which column.</param>
        /// <param name="row">Which row.</param>
        public void SetCellsAlive(bool isAlive, int column, int row)
        {
            cells[column, row] = isAlive;
        }

        /// <summary>
        /// Sets random cells to be alive.
        /// </summary>
        public void SetCellsRandomAlive()
        {
            for (int y = 0; y < cells.GetLength(0); y++)
            {
                for (int x = 0; x < cells.GetLength(1); x++)
                {
                    Random random = new Random();
                    cells[x, y] = random.Next(2) == 0;
                }
            }
        }

        /// <summary>
        /// Spawns glider.
        /// </summary>
        public void SpawnGlider()
        {
            SetCellsAlive(true, 4, 4);
            SetCellsAlive(true, 5, 5);
            SetCellsAlive(true, 6, 5);
            SetCellsAlive(true, 6, 4);
            SetCellsAlive(true, 6, 3);
        }

        /// <summary>
        /// Spawns 1 neighbour.
        /// </summary>
        public void Spawn1Neighbour()
        {
            SetCellsAlive(true, 4, 4);
            SetCellsAlive(true, 5, 5);
        }

        /// <summary>
        /// Spawns 2 neighbours.
        /// </summary>
        public void Spawn2Neighbours()
        {
            SetCellsAlive(true, 4, 4);
            SetCellsAlive(true, 5, 5);
            SetCellsAlive(true, 6, 6);
        }

        /// <summary>
        /// Spawns 3 neighbours.
        /// </summary>
        public void Spawn3Neighbours()
        {
            SetCellsAlive(true, 4, 4);
            SetCellsAlive(true, 5, 5);
            SetCellsAlive(true, 6, 6);
            SetCellsAlive(true, 4, 5);
        }
    }
}
