namespace GameOfLife.Source
{
    /// <summary>
    /// This is the main class, where the program starts.
    /// </summary>
    public class App
    {
        /// <summary>
        /// Main function.
        /// </summary>
        public static void Main()
        {
            var game = new Game();
            game.Play();
        }
    }
}
