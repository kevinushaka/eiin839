using System;
using System.IO;
using System.Net;
using System.Text;

namespace HTTPListener
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }


            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                Console.WriteLine($"Received request for {request.Url}");
                Console.WriteLine(documentContents);

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                //Get and display header fields
                Header header = new Header(request);
                Console.WriteLine("<HEADER>");
                Console.Write("Accept: ");          header.display_Accept();
                Console.Write("Accept-Encoding: "); header.display_AcceptEncoding();
                Console.Write("Accept-Language: "); header.display_AcceptLanguage();
                Console.Write("Allow: ");           header.dipslay_Allow();
                Console.Write("Authorization: ");   header.display_Authorization();
                Console.Write("Cookie: ");          header.display_Cookie();
                Console.Write("From: ");            header.display_From();
                Console.Write("User-Agent: ");      header.display_UserAgent();
                Console.WriteLine("</HEADER>");

                // Construct a response.
                string responseString = GetIndex();
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ...
            // listener.Stop();
        }

        public static string GetIndex()
        {
            string path = @"%HTTP_ROOT%\index.html";
            path = Environment.ExpandEnvironmentVariables(path);
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                return readText;
            }
            Console.WriteLine(path);
            return "<HTML><BODY> Hello world!</BODY></HTML>";

        }
    }
}
