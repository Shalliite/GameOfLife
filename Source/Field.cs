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
#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowSize(FieldWidth, FieldHeight);
#pragma warning restore CA1416 // Validate platform compatibility
        }

        /// <summary>
        /// Function that renders game field to show in console.
        /// </summary>
        /// <param name="cells">Cells to render on screen.</param>
        public void Render(Cells cells)
        {
            Console.SetCursorPosition(0, 0);
            for (int currentRow = 0; currentRow < cells.RowCount; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < cells.ColumnCount; currentColumn++)
                {
                    if (cells.GetCells()[currentColumn, currentRow])
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
