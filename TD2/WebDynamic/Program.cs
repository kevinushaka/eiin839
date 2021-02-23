﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Reflection;
namespace WebDynamic
{

    internal class Program
    {
        /**
         * 
         * Exemples URLs: 
         * localhost:8080/method/Method?param1=Bon&param2=jour  //Méthode interne
         * localhost:8081/cg-bin/Exec?param1=A&param2=bientot  //Exécutable
         * localhost:8080/webservice/Incr?val=5             // Services Web
         */
        private static void Main(string[] args)
        {

            //if HttpListener is not supported by the Framework
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

            // get args 
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            // Trap Ctrl-C on console to exit 
            Console.CancelKeyPress += delegate {
                // call methods to close socket and exit
                listener.Stop();
                listener.Close();
                Environment.Exit(0);
            };


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
                
                // get url 
                Console.WriteLine($"Received request for {request.Url}");

                //get url protocol
                Console.WriteLine(request.Url.Scheme);
                //get user in url
                Console.WriteLine(request.Url.UserInfo);
                //get host in url
                Console.WriteLine(request.Url.Host);
                //get port in url
                Console.WriteLine(request.Url.Port);
                //get path in url 
                Console.WriteLine(request.Url.LocalPath);

                // parse path in url 
                foreach (string str in request.Url.Segments)
                {
                   // Console.WriteLine(str);
                }
                //get params un url. After ? and between &

                Console.WriteLine(request.Url.Query);


                object return_value=null;
                Type t = typeof(Mymethods);
                if (request.Url.Segments.Length > 1)
                {
                    string path = request.Url.Segments[request.Url.Segments.Length - 2];
                    string methodName = request.Url.Segments[request.Url.Segments.Length - 1];
                    if (path.Equals("cg-bin/")||path.Equals("method/"))
                    {
                        //parse params in url
                        string param1 = HttpUtility.ParseQueryString(request.Url.Query).Get("param1");
                        string param2 = HttpUtility.ParseQueryString(request.Url.Query).Get("param2");
                        string[] parameters = { param1, param2 };
                        MethodInfo method = t.GetMethod(methodName);
                        return_value = method.Invoke(new Mymethods(), parameters);
                    }
                    if (path.Equals("webservice/"))
                    {
                        string param1 = HttpUtility.ParseQueryString(request.Url.Query).Get("val");
                        string[] parameters = { param1 };
                        MethodInfo method = t.GetMethod(methodName);
                        return_value = method.Invoke(new Mymethods(), parameters);
                    }
                }
                    
                //Console.WriteLine(documentContents);

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                // Construct a response.
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                if (return_value != null)
                {
                    responseString = (string)return_value;
                }
                
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ... But Ctrl-C do that ...
            // listener.Stop();
        }
    }
}