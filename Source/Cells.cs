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
            cells = new bool[rowCount, columnCount];
        }

        /// <summary>
        /// Gets the cell array.
        /// </summary>
        /// <returns>Cell array with data.</returns>
        public bool[,] GetCells()
        {
            return cells;
        }

        /// <summary>
        /// Function that processes main cell logic.
        /// </summary>
        /// <param name="sleepTime">How fast cells needs to be updated.</param>
        public void CalculateNextIteration(ushort sleepTime)
        {
            bool[,] nextGenerationCells = new bool[cells.GetLength(0), cells.GetLength(1)];
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
                    liveCellCount = cells[currentRow, previousColumn] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[previousRow, previousColumn] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[previousRow, currentColumn] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[previousRow, nextColumn] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[currentRow, nextColumn] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[nextRow, nextColumn] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[nextRow, currentColumn] ? (ushort)1 : (ushort)0;
                    liveCellCount += cells[nextRow, previousColumn] ? (ushort)1 : (ushort)0;

                    bool isCurrentCellAlive = false;
                    switch (liveCellCount)
                    {
                        case 3:
                            isCurrentCellAlive = true;
                            break;
                        case 2:
                            if (cells[currentRow, currentColumn])
                            {
                                isCurrentCellAlive = true;
                            }
                            break;
                    }

                    nextGenerationCells[currentRow, currentColumn] = isCurrentCellAlive;
                }
            }

            cells = nextGenerationCells;
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
            cells[row, column] = isAlive;
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
                    cells[y, x] = random.Next(2) == 0;
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
