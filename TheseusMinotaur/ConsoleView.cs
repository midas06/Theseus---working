using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
    class ConsoleView : IView
    {
        public void Start()
        {
            Console.Clear();
        }

        public int SetLevel(string prompt = "")
        {
            Console.WriteLine(prompt);
            return int.Parse(Console.ReadLine());
        }
        public void Display<T>(T message)
        {
            Console.WriteLine(message);
        }

        public void Stop()
        {
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }

      
    }
}
