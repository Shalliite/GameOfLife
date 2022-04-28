namespace GameOfLife.Source
{
    /// <summary>
    /// Class that is used to process input from the user.
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Function that process selection from user what kind/size of game field needs to be created.
        /// </summary>
        /// <param name="description">Some description message to ask what needs to be inputed.</param>
        /// <param name="minValue">Smallest size for field.</param>
        /// <param name="maxValue">Biggest size for field.</param>
        /// <returns>Inputed number from console.</returns>
        public static ushort ProcessInput(string description, ushort minValue, ushort maxValue)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowSize(120, 30);
#pragma warning restore CA1416 // Validate platform compatibility
            do
            {
                Console.Clear();
                Console.WriteLine(description);
                if (ushort.TryParse(Console.ReadLine(), out ushort output))
                {
                    if (output < minValue)
                    {
                        Console.WriteLine(Resources.Resources.ErrorMessageNumberTooSmall, minValue);
                        Console.ReadKey();
                    }
                    else if (output > maxValue)
                    {
                        Console.WriteLine(Resources.Resources.ErrorMessageNumberTooBig, maxValue);
                        Console.ReadKey();
                    }
                    else
                    {
                        return output;
                    }
                }
                else
                {
                    Console.WriteLine(Resources.Resources.ErrorMessageNotANumber);
                    Console.ReadKey();
                }
            }
            while (true);
        }
    }
}
