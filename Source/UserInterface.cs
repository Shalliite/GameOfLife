namespace GameOfLife.Source
{
    /// <summary>
    /// Class that is used to process input from the user.
    /// </summary>
    public static class UserInterface
    {
        public static string errorMessageNotNumber = "Input is not a number!";
        
        /// <summary>
        /// Function that process selection from user what kind/size of game field needs to be created.
        /// </summary>
        /// <param name="description">Some description message to ask what needs to be inputed.</param>
        /// <param name="minValue">Smallest size for field.</param>
        /// <param name="maxValue">Biggest size for field.</param>
        /// <returns>Inputed number from console.</returns>
        public static ushort ProcessInput(string description, ushort minValue, ushort maxValue)
        {
            string errorMessageNumberTooBig = $"Number too big. Should be less than: { maxValue }";
            string errorMessageNumberTooSmall = $"Number too small. Should be bigger than: { minValue }";
            do
            {
#pragma warning disable CA1416 // Validate platform compatibility
                Console.SetWindowSize(120, 30);
#pragma warning restore CA1416 // Validate platform compatibility
                Console.Clear();
                Console.WriteLine(description);
                if (ushort.TryParse(Console.ReadLine(), out ushort output))
                {
                    if (output < minValue)
                    {
                        Console.WriteLine(errorMessageNumberTooSmall);
                        Console.ReadKey();
                    }
                    else if (output > maxValue)
                    {
                        Console.WriteLine(errorMessageNumberTooBig);
                        Console.ReadKey();
                    }
                    else
                    {
                        return output;
                    }
                }
                else
                {
                    Console.WriteLine(errorMessageNotNumber);
                    Console.ReadKey();
                }
            }
            while (true);
        }
    }
}
