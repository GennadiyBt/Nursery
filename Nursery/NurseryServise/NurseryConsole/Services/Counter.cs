using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Services
{
    public class Counter : IDisposable
    {
        static int count = 0;
        public Counter() { count++; }

        public void Dispose()
        {
            Console.WriteLine("Resurse closed");
        }
    }
}
