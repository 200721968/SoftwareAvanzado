using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumirWsSA
{
    class Program
    {
        static void Main(string[] args)
        {

            string result = GetPost();
            string token = "";

            var separar = result.ToString();
            var cadena = separar.Split('"');
            token = cadena[3].ToString();
            


            
        }

        public static string GetPost() {
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
}
