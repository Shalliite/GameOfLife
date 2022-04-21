namespace GameOfLife.Source
{
    /// <summary>
    /// Class for new cells to be created.
    /// </summary>
    public class Cells
    {
        /// <summary>
        /// Property used to store current column count for cells.
        /// </summary>
        public ushort ColumnCount { get; protected set; }
        /// <summary>
        /// Property used to store current row count for cells.
        /// </summary>
        public ushort RowCount { get; protected set; }
        /// <summary>
        /// Property used to store current cell count that are alive.
        /// </summary>
        public ushort LiveCellCount { get { return GetCurrentLiveCellCount(); } }
        /// <summary>
        /// Property used to store current cells.
        /// </summary>
        public bool[,] CellArray { get { return cells; } }
        /// <summary>
        /// Property used to store current generation.
        /// </summary>
        public uint Generation { get; protected set; } = 1;
        private bool[,] cells;
        private bool[,] nextGenerationCells;

        /// <summary>
        /// Constructs new cell instance.
        /// </summary>
        /// <param name="columnCount">Cell column count.</param>
        /// <param name="rowCount">Cell row count.</param>
        public Cells(ushort columnCount, ushort rowCount)
        {
            ColumnCount = columnCount;
            RowCount = rowCount;
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
            nextGenerationCells = new bool[ColumnCount, RowCount];
            for (int currentRow = 0; currentRow < RowCount; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < ColumnCount; currentColumn++)
                {
                    ushort liveCellCount;

                    int nextRow = currentRow == RowCount - 1 ? 0 : currentRow + 1;
                    int previousRow = currentRow == 0 ? RowCount - 1 : currentRow - 1;
                    int nextColumn = currentColumn == ColumnCount - 1 ? 0 : currentColumn + 1;
                    int previousColumn = currentColumn == 0 ? ColumnCount - 1 : currentColumn - 1;

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
        /// <exception cref="IndexOutOfRangeException">If given cell is not present in field.</exception>
        public void SetCellsAlive(bool isAlive, int column, int row)
        {
            if(column < 0 || row < 0 || column > ColumnCount - 1 || row > RowCount - 1)
            {
                throw new IndexOutOfRangeException("Cannot set cells outside of bounds!");
            }

            cells[column, row] = isAlive;
        }

        /// <summary>
        /// Sets random cells to be alive.
        /// </summary>
        public void SetCellsRandomAlive()
        {
            for (int y = 0; y < RowCount; y++)
            {
                for (int x = 0; x < ColumnCount; x++)
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
