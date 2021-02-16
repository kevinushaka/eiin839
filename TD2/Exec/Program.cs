using System;

namespace Exec
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 1)
                Console.WriteLine("<HTML><BODY> Hello " + args[0] + " et " + args[1] + "</BODY></HTML>");
        }
    }
}
