namespace GameOfLife.Source
{
    /// <summary>
    /// Utility class for console configuration and other stuff.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Clears current console line.
        /// </summary>
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
