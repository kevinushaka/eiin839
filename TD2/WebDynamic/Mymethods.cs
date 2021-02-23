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
     * Elle contient  une  méthode  <mymethod>(string <parm1_value>, string <param2_value>) qui sera appelée sur une invocation de type
     * http://localhost:8080/<ceque_vousvoulez>/<ceque_vousvoulez>/<MyMethod>?param1=<ceque_vousvoulez>& param2=<ceque_vousvoulez>
     * @author Kevin Ushaka Kubwawe
     * 
     */
    public class Mymethods
    {
        public Mymethods()
        {

        }
        public string Exec(string param1, string param2)
        {
            //
            // Set up the process with the ProcessStartInfo class.
            // https://www.dotnetperls.com/process
            //
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\keush\Projects\soc-ws-20-21\eiin839\TD2\Exec\bin\Debug\Exec.exe"; // Specify exe name.
            start.Arguments = param1 + " " + param2; // Specify arguments.
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
        public string Method(string param1, string param2)
        {
            return "<HTML><BODY> Hello " + param1 + " et " + param2 + "</BODY></HTML>";
        }
        public string Incr(string param)
        {
            int val = int.Parse(param);
            val++;
            return "{ \"status\":200, \"val\":" + val + "}";
        }
    }

   
}
