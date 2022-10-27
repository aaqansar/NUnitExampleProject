using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject.GetEndPoint
{
    internal class TestGetEndPoint
    {
        private string getUrl = "https://reqres.in/api/users";
        HttpClient? client;

        [Test]
        public void TestApiByStringURL()
        {
            client = new HttpClient();
            client.GetAsync(getUrl);
            client.Dispose();
        }

        [Test]
        public void TestApiByUriMethod()
        {
            client = new HttpClient();

            Uri uri = new Uri(getUrl);

            Task<HttpResponseMessage> httpResponse=  client.GetAsync(uri);

            HttpResponseMessage responseMessage = httpResponse.Result;
            
            HttpStatusCode statusCode= responseMessage.StatusCode;

            Console.WriteLine("Status --> {0}",statusCode);

            Console.WriteLine("Status Code --> {0}", (int)statusCode);

            HttpContent responseContent = responseMessage.Content;

            Task<string> responseBody = responseContent.ReadAsStringAsync();

            string data=responseBody.Result;

            Console.WriteLine("Data --> {0}", data);

            client.Dispose();
        }
    }
}
