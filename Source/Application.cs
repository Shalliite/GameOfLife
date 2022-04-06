using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Source
{
    public class Application
    {
        public Application()
        {
            Console.SetWindowSize(4, 2);
            Console.Clear();
        }
        public void Run()
        {

        }
        public static void Main()
        {
            Application app = new Application();
            app.Run();
        }
    }
}
