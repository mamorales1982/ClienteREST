using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClientREST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("Cliente REST ");
            Console.WriteLine(" ");

            Console.WriteLine("ingrese el numero del dia que desea ver el pronostico  ");
            String number;
            Console.WriteLine(" ");
            number = Console.ReadLine();


            string url = string.Format("http://galaxiawebservicerest.azurewebsites.net/api/Clima/Clima?id="+ number);
            string details = CallRestMethod(url);
        }

        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
           // webrequest.Headers.Add("Username", "xyz");
           // webrequest.Headers.Add("Password", "abc");
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            Console.WriteLine("");
            Console.WriteLine("Respuesta: " + result);
            Console.ReadKey();
            return result;
        }
    }
}
