namespace GameOfLife.Source
{
    /// <summary>
    /// Class for new fields to be created.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Constructor to construct new field instance.
        /// </summary>
        /// <param name="width">Field width.</param>
        /// <param name="height">Field height.</param>
        public Field()
        {
            Console.Clear();
        }

        /// <summary>
        /// Function for updating field dimensions.
        /// </summary>
        public void UpdateDimensions(ushort width, ushort height)
        {
            int windowWidth = width < 33 ? windowWidth = 33 : windowWidth = width;
            int windowHeight = height + 3; //because of space to render text
#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowSize(windowWidth, windowHeight);
#pragma warning restore CA1416 // Validate platform compatibility
        }

        /// <summary>
        /// Function that renders game field to show in console.
        /// </summary>
        /// <param name="cells">Cells to render on screen.</param>
        public void Render(Cells cells)
        {
            const char aliveCell = '#';
            const char deadCell = '.';
            const char newLine = '\n';
            Console.SetCursorPosition(0, 0);
            Utilities.ClearCurrentConsoleLine();
            Console.WriteLine($"Current generation: {cells.Generation}");
            Utilities.ClearCurrentConsoleLine();
            Console.WriteLine($"Current live cell count: {cells.LiveCellCount}");
            for (int currentRow = 0; currentRow < cells.CellArray.GetLength(0); currentRow++)
            {
                for (int currentColumn = 0; currentColumn < cells.CellArray.GetLength(1); currentColumn++)
                {
                    if (cells.CellArray[currentRow, currentColumn])
                    {
                        Console.Write(aliveCell);
                    }
                    else
                    {
                        Console.Write(deadCell);
                    }
                }
                Console.Write(newLine);
            }
        }
    }
}
