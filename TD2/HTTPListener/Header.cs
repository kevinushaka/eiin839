using System;
using System.Text;
using System.Net;

namespace HTTPListener
{
    /**
     * The Header class allows you to retrieve and display the fields of the HTTP header of each request received by the server.
     * @author Kevin USHAKA KUBWAWE
     */
    class Header
    {

        string Accept { get; } //The MIME types that are acceptable for the response.
        string AcceptEncoding { get; } //The content encodings that are acceptable for the response.
        string AcceptLanguage { get; } //Natural languages that are preferred for the response.
        string Allow { get; } //The set of HTTP methods supported.
        string Authorization { get; } //The credentials that the client presents in order to authenticate itself to the server.
        string Cookie { get; } //Cookie data presented to the server.
        string From { get; } //Internet Email address for the human user who controls the requesting user agent.
        string UserAgent { get; }//Information about the client agent.


        public Header(HttpListenerRequest request)
        {
            //The problem with HttpRequestHeader is that some of the names have dashes ("-") in them. 
            //For instance, "Accept" works but "Accept-Encoding" does not.
            Accept = request.Headers.Get(HttpRequestHeader.Accept.ToString());
            AcceptEncoding = request.Headers.Get(TranslateToHttpHeaderName(HttpRequestHeader.AcceptEncoding));
            AcceptLanguage = request.Headers.Get(TranslateToHttpHeaderName(HttpRequestHeader.AcceptLanguage));
            Allow = request.Headers.Get(HttpRequestHeader.Allow.ToString());
            Authorization = request.Headers.Get(HttpRequestHeader.Authorization.ToString());
            Cookie = request.Headers.Get(HttpRequestHeader.Cookie.ToString());
            From = request.Headers.Get(HttpRequestHeader.From.ToString());
            UserAgent = request.Headers.Get(TranslateToHttpHeaderName(HttpRequestHeader.UserAgent));
        }

        public void write()
        {
            Console.WriteLine(HttpRequestHeader.Accept.ToString() + " : " + Accept);
            Console.WriteLine(HttpRequestHeader.AcceptEncoding.ToString() + " : " + AcceptEncoding);
            Console.WriteLine(HttpRequestHeader.AcceptLanguage.ToString() + " : " + AcceptLanguage);
            Console.WriteLine(HttpRequestHeader.Allow.ToString() + " : " + Allow);
            Console.WriteLine(HttpRequestHeader.Authorization.ToString() + " : " + Authorization);
            Console.WriteLine(HttpRequestHeader.Cookie.ToString() + " : " + Cookie);
            Console.WriteLine(HttpRequestHeader.From.ToString() + " : " + From);
            Console.WriteLine(HttpRequestHeader.Accept.ToString() + " : " + UserAgent);
        }

        /**
         * @see https://stackoverflow.com/questions/25574333/how-to-use-system-net-httprequestheader-enum-with-an-asp-net-request
         */
        public static string TranslateToHttpHeaderName(HttpRequestHeader enumToTranslate)
        {
            const string httpHeaderNameSeparator = "-";
            string enumName = enumToTranslate.ToString();
            var stringBuilder = new StringBuilder();

            // skip first letter
            stringBuilder.Append(enumName[0]);
            for (int i = 1; i < enumName.Length; i++)
            {
                if (char.IsUpper(enumName[i])) stringBuilder.Append(httpHeaderNameSeparator);
                stringBuilder.Append(enumName[i]);
            }
            // Cover special case for 2 character enum name "Te" to "TE" header case.
            string headerName = stringBuilder.ToString();
            if (headerName.Length == 2) headerName = headerName.ToUpper();
            return headerName;
        }

    }
}
