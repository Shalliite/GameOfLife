namespace GameOfLife.Source
{
    /// <summary>
    /// Class for new fields to be created.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Property used to store current field width.
        /// </summary>
        public ushort FieldWidth { get; protected set; }
        /// <summary>
        /// Property used to store current field height.
        /// </summary>
        public ushort FieldHeight { get; protected set; }
        private ushort rowToStartRenderingCells = 4;

        /// <summary>
        /// Constructor to construct new field instance.
        /// </summary>
        /// <param name="width">Field width.</param>
        /// <param name="height">Field height.</param>
        public Field(ushort width, ushort height)
        {
            FieldWidth = width;
            FieldHeight = height;
            Console.Clear();
        }

        /// <summary>
        /// Function for updating field dimensions.
        /// </summary>
        public void UpdateDimensions()
        {
            int windowWidth = FieldWidth < 33 ? windowWidth = 33 : windowWidth = FieldWidth;
            int windowHeight = FieldHeight + 3; //because of space to render text
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
            Console.SetCursorPosition(0, 0);
            Utilities.ClearCurrentConsoleLine();
            Console.WriteLine($"Current generation: {cells.Generation}");
            Utilities.ClearCurrentConsoleLine();
            Console.WriteLine($"Current live cell count: {cells.LiveCellCount}");
            for (int currentRow = 0; currentRow < cells.RowCount; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < cells.ColumnCount; currentColumn++)
                {
                    if (cells.CellArray[currentColumn, currentRow])
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
