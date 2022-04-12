using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Source
{
    public static class UserInterface
    {
        public static string errorMessageNotNumber = "Input is not a number!";
        
        public static ushort ProcessInput(string description, ushort minValue, ushort maxValue)
        {
            string errorMessageNumberTooBig = $"Number too big. Should be less than: { maxValue }";
            string errorMessageNumberTooSmall = $"Number too small. Should be bigger than: { minValue }";
            do
            {
                Console.SetWindowSize(120, 30);
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
