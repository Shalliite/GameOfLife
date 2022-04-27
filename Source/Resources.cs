using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Source
{
    /// <summary>
    /// This class is for getting information and configurations/properties from file.
    /// </summary>
    public class Resources
    {
        /// <summary>
        /// Game field width info.
        /// </summary>
        public string EnterGameFieldWidthInfo { get; private set; }
        /// <summary>
        /// Game field height info.
        /// </summary>
        public string EnterGameFieldHeightInfo { get; private set; }
        /// <summary>
        /// Not a number info.
        /// </summary>
        public string ErrorMessageNotANumber { get; private set; }
        /// <summary>
        /// Number too small info.
        /// </summary>
        public string ErrorMessageNumberTooSmall { get; private set; }
        /// <summary>
        /// Number too big info.
        /// </summary>
        public string ErrorMessageNumberTooBig { get; private set; }
        /// <summary>
        /// Alive cell.
        /// </summary>
        public string AliveCell { get; private set; }
        /// <summary>
        /// Dead cell.
        /// </summary>
        public string DeadCell { get; private set; }
        /// <summary>
        /// Standard console width.
        /// </summary>
        public ushort StandardConsoleWidth { get; private set; }
        /// <summary>
        /// Standard console height.
        /// </summary>
        public ushort StandardConsoleHeight { get; private set; }
        /// <summary>
        /// Specifies minimum console game width.
        /// </summary>
        public ushort GameMinimumConsoleWidth { get; private set; }
        /// <summary>
        /// Specifies maximum field width.
        /// </summary>
        public ushort MaximumFieldWidth { get; private set; }
        /// <summary>
        /// Specifies minimum field height.
        /// </summary>
        public ushort MinimumFieldWidth { get; private set; }
        /// <summary>
        /// Specifies maximum field height.
        /// </summary>
        public ushort MaximumFieldHeight { get; private set; }
        /// <summary>
        /// Specifies minimum field height.
        /// </summary>
        public ushort MinimumFieldHeight { get; private set; }

        /// <summary>
        /// Loads info/properties from file into program.
        /// </summary>
        public Resources()
        {
            char openingBrace = '[';
            char closingBrace = ']';
            string resourceDir = "../../../Resources/Resources.txt";
            List<string> contents = new List<string>();
            StreamReader sr = new StreamReader(resourceDir);
            while (!sr.EndOfStream)
            {
                contents.Add(sr.ReadLine());
            }
            for (int i = 0; i < contents.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        MinimumFieldWidth = ushort.Parse(StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace));
                        break;
                    case 1:
                        MaximumFieldWidth = ushort.Parse(StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace));
                        break;
                    case 2:
                        MinimumFieldHeight = ushort.Parse(StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace));
                        break;
                    case 3:
                        MaximumFieldHeight = ushort.Parse(StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace));
                        break;
                    case 4:
                        EnterGameFieldWidthInfo = string.Format(StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace), MinimumFieldWidth, MaximumFieldWidth);
                        break;
                    case 5:
                        EnterGameFieldHeightInfo = string.Format(StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace), MinimumFieldHeight, MaximumFieldHeight);
                        break;
                    case 6:
                        ErrorMessageNotANumber = StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace);
                        break;
                    case 7:
                        ErrorMessageNumberTooSmall = StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace);
                        break;
                    case 8:
                        ErrorMessageNumberTooBig = StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace);
                        break;
                    case 9:
                        AliveCell = StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace);
                        break;
                    case 10:
                        DeadCell = StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace);
                        break;
                    case 11:
                        //not used for now.
                        break;
                    case 12:
                        StandardConsoleWidth = ushort.Parse(StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace));
                        break;
                    case 13:
                        StandardConsoleHeight = ushort.Parse(StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace));
                        break;
                    case 14:
                        GameMinimumConsoleWidth = ushort.Parse(StringManipulation.ReturnBetween(contents[i], openingBrace, closingBrace));
                        break;

                }
            }
        }
    }
}
