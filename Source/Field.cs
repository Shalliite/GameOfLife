using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Source
{
    public class Field
    {
        public ushort FieldWidth { get; protected set; }
        public ushort FieldHeight { get; protected set; }

        public Field(ushort width, ushort height)
        {
            FieldWidth = width;
            FieldHeight = height;
            Console.Clear();
        }

        public void UpdateDimensions()
        {
            Console.SetWindowSize(FieldWidth, FieldHeight);
        }

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
