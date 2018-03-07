using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            JJSOFT.LIVING.LivingDog ld = new JJSOFT.LIVING.LivingDog();
            var r = ld.Grand_OpenDog(0x53584a4a, 0);
            Console.WriteLine(r.ToString());
            Console.ReadLine();
        }
    }
}
