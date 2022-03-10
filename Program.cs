using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsigTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultarMargen();
            Console.ReadKey(); 
        }


        private static void ConsultarMargen()
        {
            var objetoRequest = new Request();
            var json = JsonConvert.SerializeObject(objetoRequest);
            var certificate = new X509Certificate2();
            certificate.Import(@"C:\Users\nando\Dropbox\PC\Documents\ALGORIX SERVIÇO\Repos tasks Joao\CertificadoConsig\somaBnk.pfx", "algx135", X509KeyStorageFlags.DefaultKeySet);
            var request = (HttpWebRequest)WebRequest.Create("https://webservice-v3.consignet.com.br:8197/consultar-margem");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            request.Method = "POST";
            request.ContentType = "application/json";
            ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate2,
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
            request.ClientCertificates.Add(certificate);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var parse = JObject.Parse(result);
                    foreach (var item in parse)
                    {
                        Console.WriteLine("{0}: {1}", item.Key, item.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
