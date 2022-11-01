using Newtonsoft.Json;
using NUnitExampleProject.Model;
using NUnitExampleProject.Model.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace NUnitExampleProject.PostEndPoint
{
    public class TestPostEndPoint
    {
        private string postUrl = "https://reqres.in/api/users";
        private string postLoginUrl = "https://jsonplaceholder.typicode.com/users";
        



        [Test, Order(1)]
        public void TestPostApiAsyncByURL()
        {

            HttpClient client= new HttpClient();

            //input parameter
            var jsonData = new
            {
                name = "Test",
                job = "Automation"  
            };
            
            //creating Json for Input Parameter
            var formattedJsonDta = JsonConvert.SerializeObject(new List<object>() { jsonData });
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //Changing Json into String Content
            var stringContent = new StringContent(formattedJsonDta, Encoding.UTF8, "application/json");

            //Getting Response
            Task<HttpResponseMessage> msg= client.PostAsync(postUrl, stringContent);
            HttpResponseMessage response = msg.Result;
            Console.WriteLine(response.ToString());

            //Getting Status
            HttpStatusCode statusCode = response.StatusCode;
            Console.WriteLine("Status {0}",statusCode);
            Console.WriteLine("Status Code {0}", (int)statusCode);

            //Getting Content
            HttpContent cont = response.Content;
            Task<string> responseBody = cont.ReadAsStringAsync();
            string data = responseBody.Result;
            Console.WriteLine("Response :{0}", data);

            RestResponse rr = new RestResponse((int)statusCode, data);

            Console.WriteLine(rr.ToString());

            //var model = JsonConvert.DeserializeObject<RootList>(rr.ResponseData);
            
            client.Dispose();
        }

        [Test, Order(2)]
        public void TestPostApiAsyncForLogin()
        {

            HttpClient client = new HttpClient();

            //input parameter
            var jsonData = new
            {
                id= 11,
                name= "Krishna Rungta",
                username= "Bret",
                email= "Sincere@april.biz",
                address = new[]
                {
                    new
                    {
                     street= "Kulas Light",
                     suite= "Apt. 556",
                     city= "Gwenborough",
                     zipcode= "92998-3874",
                     geo = new[]
                        {
                        new
                        {
                         lat= "-37.3159",
                         lng= "81.1496",
                        }
                     } 
                  } 
                },
                phone= "1-770-736-8031 x56442",
                website= "hildegard.org",
                company = new[]
                {
                     new
                    {
                     name= "Romaguera-Crona",
                     catchPhrase= "Multi-layered client-server neural-net",
                     bs= "harness real-time e-markets"
                     }
                }
            };

            //creating Json for Input Parameter
            var formattedJsonDta = JsonConvert.SerializeObject(new List<object>() { jsonData });
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //Changing Json into String Content
            var stringContent = new StringContent(formattedJsonDta, Encoding.UTF8, "application/json");

            //Getting Response
            Task<HttpResponseMessage> msg = client.PostAsync(postLoginUrl, stringContent);
            HttpResponseMessage response = msg.Result;
            Console.WriteLine(response.ToString());

            //Getting Status
            HttpStatusCode statusCode = response.StatusCode;
            Console.WriteLine("Status {0}", statusCode);
            Console.WriteLine("Status Code {0}", (int)statusCode);

            //Getting Content
            HttpContent cont = response.Content;
            Task<string> responseBody = cont.ReadAsStringAsync();
            string data = responseBody.Result;
            Console.WriteLine("Response :{0}", data);

            RestResponse rr = new RestResponse((int)statusCode, data);

            Console.WriteLine(rr.ToString());

            //var model = JsonConvert.DeserializeObject<RootList>(rr.ResponseData);

            client.Dispose();
        }
    }
}
