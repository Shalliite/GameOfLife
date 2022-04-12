using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Source
{
    public class Game
    {
        Field? field;
        Cells? cells;
        public bool shouldRun = false;

        public void Play(ushort fieldWidth, ushort fieldHeight)
        {
            field = new Field(fieldWidth, fieldHeight);
            cells = new Cells(fieldWidth, fieldHeight);
            shouldRun = true;
            Thread checkIfShouldRun = new Thread(CheckIfShouldRun);
            checkIfShouldRun.Start();
            cells.SpawnGlider();

            while (shouldRun)
            {
                field.UpdateDimensions();
                field.Render(cells);
                cells.CalculateNextIteration(900);
            }

            checkIfShouldRun.Join();
        }

        public void CheckIfShouldRun()
        {
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                shouldRun = true;
            }
            shouldRun = false;
        }
    }
}
