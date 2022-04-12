using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Source
{
    public class Cells
    {
        public ushort ColumnCount { get; protected set; }
        public ushort RowCount { get; protected set; }
        private bool[,] cells;
        private bool[,] nextGenerationCells;

        public Cells(ushort columnCount, ushort rowCount)
        {
            ColumnCount = columnCount;
            RowCount = rowCount;
            cells = new bool[columnCount, rowCount];
        }

        public bool[,] GetCells()
        {
            return cells;
        }

        public void CalculateNextIteration(ushort sleepTime)
        {
            nextGenerationCells = new bool[ColumnCount, RowCount];
            for (int currentRow = 0; currentRow < RowCount; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < ColumnCount; currentColumn++)
                {
                    ushort liveCellCount = 0;

                    int nextRow = currentRow == RowCount - 1 ? 0 : currentRow + 1;
                    int previousRow = currentRow == 0 ? RowCount - 1 : currentRow - 1;
                    int nextColumn = currentColumn == ColumnCount - 1 ? 0 : currentColumn + 1;
                    int previousColumn = currentColumn == 0 ? ColumnCount - 1 : currentColumn - 1;

                    //check if there is something arround
                    if (cells[previousColumn, currentRow])
                        liveCellCount++;
                    if (cells[previousColumn, previousRow])
                        liveCellCount++;
                    if (cells[currentColumn, previousRow])
                        liveCellCount++;
                    if (cells[nextColumn, previousRow])
                        liveCellCount++;
                    if (cells[nextColumn, currentRow])
                        liveCellCount++;
                    if (cells[nextColumn, nextRow])
                        liveCellCount++;
                    if (cells[currentColumn, nextRow])
                        liveCellCount++;
                    if (cells[previousColumn, nextRow])
                        liveCellCount++;

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
            Thread.Sleep(sleepTime);
        }

        public void SetCellsAlive(bool isAlive, int column, int row)
        {
            if(column < 0 || row < 0 || column > ColumnCount - 1 || row > RowCount - 1)
            {
                throw new IndexOutOfRangeException("Cannot set cells outside of bounds!");
            }
            cells[column, row] = isAlive;
        }

        public void SetCellsAlive(bool isAlive)
        {
            for (int y = 0; y < RowCount; y++)
            {
                for (int x = 0; x < ColumnCount; x++)
                {
                    cells[x, y] = isAlive;
                }
            }
        }

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

        public void SpawnGlider()
        {
            SetCellsAlive(true, 4, 4);
            SetCellsAlive(true, 5, 5);
            SetCellsAlive(true, 6, 5);
            SetCellsAlive(true, 6, 4);
            SetCellsAlive(true, 6, 3);
        }

        public void Spawn1Neighbour()
        {
            SetCellsAlive(true, 4, 4);
            SetCellsAlive(true, 5, 5);
        }

        public void Spawn2Neighbours()
        {
            SetCellsAlive(true, 4, 4);
            SetCellsAlive(true, 5, 5);
            SetCellsAlive(true, 6, 6);
        }

        public void Spawn3Neighbours()
        {
            SetCellsAlive(true, 4, 4);
            SetCellsAlive(true, 5, 5);
            SetCellsAlive(true, 6, 6);
            SetCellsAlive(true, 4, 5);
        }
    }
}
