using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Source
{
    /// <summary>
    /// Custom string manipulation class.
    /// </summary>
    public class StringManipulation
    {
        /// <summary>
        /// This function is used to get the content that is between 2 specific characters.
        /// </summary>
        /// <param name="content">Content to look for.</param>
        /// <param name="a">Opening character.</param>
        /// <param name="b">Closing character.</param>
        /// <returns></returns>
        public static string ReturnBetween(string content, char a, char b)
        {
            string temp = "";
            for (int i = 0; i < content.Length; i++)
            {
                if (i > content.IndexOf(a) && i < content.IndexOf(b))
                {
                    temp += content[i];
                }
            }
            return temp;
        }
    }
}
