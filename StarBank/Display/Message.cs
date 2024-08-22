using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBank.Display
{
    public class Message
    {
        public void Text(string message)
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("Sistema: " + message);
            Console.WriteLine("=======================================================");
        }
    }
}
