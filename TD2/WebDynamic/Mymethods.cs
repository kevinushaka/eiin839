using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace WebDynamic
{
    /**
     * Le classe Mymethods permet de récupérer les documents depuis un éxécutable.
     * @author Kevin Ushaka Kubwawe
     * 
     */
    public class Mymethods
    {
        public Mymethods()
        {

        }
        public string ExecTest(string param1, string param2)
        {
            //
            // Set up the process with the ProcessStartInfo class.
            // https://www.dotnetperls.com/process
            //
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\keush\Projects\soc-ws-20-21\eiin839\TD2\Exec\bin\Debug\ExecTest.exe"; // Specify exe name.
            start.Arguments = param1+" "+param2; // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    return result;
                }
            }
        }
    }
}
