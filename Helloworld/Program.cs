using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Message message = new Message(9,12,19);
            string exit = "";
            do
            {
                Console.WriteLine(message.GetHelloMessage());
                exit = Console.ReadLine();
            } while (exit != "exit");
            Console.WriteLine("Bah Salut !! ");
            
        }
    }
}
