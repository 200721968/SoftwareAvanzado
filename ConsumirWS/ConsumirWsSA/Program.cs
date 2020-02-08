using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumirWsSA
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obtener token de Acceso
                string result = GetToken();
                string token = "";
                //Obtener Repuesta de Retorno con el Token de Acceso
                    var separar = result.ToString();
                    var cadena = separar.Split('"');
                    token = cadena[3].ToString();

            //Crear 10 Contactos
                CrearContactos(token);
            //Listar ContactosTodos
                 ListarContactos(token);
            //Listar Contacto con id
                 ListarContactos(token,248);
            Console.ReadKey();
            
        }

        public static string GetToken() {
            ParamsReq param = new ParamsReq
            {
                grant_type = "client_credentials",
                client_id = "pluisgarcia@gmail.com",
                client_secret = 200721968
            };

            //ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = JsonConvert.SerializeObject(param);
            //byte[] data = encoding.GetBytes(postData);



            string result = "";
            string urlMetodo = "https://api.softwareavanzado.world/index.php?option=token&api=oauth2";

            WebRequest myReq = WebRequest.Create(urlMetodo);
            myReq.Method = "POST";
            myReq.ContentType = "application/json";
            using (var osw = new StreamWriter(myReq.GetRequestStream()))
            {
                osw.Write(postData);
                osw.Flush();
                osw.Close();
            }

            WebResponse response = myReq.GetResponse();
            using (var osr = new StreamReader(response.GetResponseStream()))
            {
                result = osr.ReadToEnd();
            }
            return result;

        }
        public static void CrearContactos(string token)
        {
            List<CreateContact> Lista = new List<CreateContact>();

            for (int i = 0; i < 10; i++) {

                CreateContact nuevo = new CreateContact
                {
                    name="P_20072196"+i,
                    catid=i+1
                    
                };

                Lista.Add(nuevo);
                    
            }

            //ASCIIEncoding encoding = new ASCIIEncoding();
           string postData2 = JsonConvert.SerializeObject(Lista);
            //byte[] data = encoding.GetBytes(postData);



           
            string urlMetodo = "https://api.softwareavanzado.world/index.php?webserviceClient=administrator&webserviceVersion=1.0.0&option=contact&api=hal&access_token=" + token;
            WebRequest myReq = WebRequest.Create(urlMetodo);
            myReq.Method = "POST";
            myReq.ContentType = "application/json";
            using (var osw = new StreamWriter(myReq.GetRequestStream()))
            {
                osw.Write(postData2);
                osw.Flush();
                osw.Close();
            }

           
        }

        async static void ListarContactos(string token)
        {
            string urlMetodo = "https://api.softwareavanzado.world/index.php?webserviceClient=administrator&webserviceVersion=1.0.0&option=contact&api=hal&access_token=" + token;

            string UrlconID = "https://api.softwareavanzado.world/index.php?webserviceClient=administrator&webserviceVersion=1.0.0&option=contact&id=248&api=hal&access_token=" + token;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(UrlconID))
                {
                    using (HttpContent content = response.Content)
                    {
                        string contenido = await content.ReadAsStringAsync();
                        Console.WriteLine(contenido);
                    } 
                }
            }
            


        }

        async static void ListarContactos(string token, int id)
        {
          
            string UrlconID = "https://api.softwareavanzado.world/index.php?webserviceClient=administrator&webserviceVersion=1.0.0&option=contact&id="+id+"&api=hal&access_token=" + token;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(UrlconID))
                {
                    using (HttpContent content = response.Content)
                    {
                        string contenido = await content.ReadAsStringAsync();
                        Console.WriteLine(contenido);
                    }
                }
            }



        }

    }

    
    public class ParamsReq
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public int client_secret { get; set; }// public string Comentario { get; set; }
        
    }

    public class RespuestaReq
    {

        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type{ get; set; }
        public string scope { get; set; }
        public string refresh_token{ get; set; }
        public string expireTimeFormatted { get; set; }
        public string created { get; set; }
       

    }

    public class Profile
    {
        public int id {get; set; }
        public string name{ get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string registerDate { get; set; }
        public string lastVisitDate { get; set; }
        public string authorisedGroups { get; set; }

    }

    public class CreateContact { 

      public string  name { get; set; }
      public int catid { get; set; }
      public string  language { get; set; }
      public int  published { get; set; }

    }

    public class ContactRead {

    }
}
