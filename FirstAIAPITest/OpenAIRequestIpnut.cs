using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAIAPITest
{
    internal class OpenAIRequestIpnut
    {
        public string promt { get; set; }

        public void RequestIpnut()
        {
            Console.WriteLine("Hi, I am BEX 0.6.0");
            Console.WriteLine("what can I help you with?");
            promt = Console.ReadLine();
        }
    }
}
