using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject.GetEndPoint
{
    internal class TestGetEndPoint
    {
        private string getUrl = "https://reqres.in/api/users/2";
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
            MediaTypeWithQualityHeaderValue md = new MediaTypeWithQualityHeaderValue("application/xml");
            HttpClient client1 = new HttpClient();

            HttpRequestHeaders header = client1.DefaultRequestHeaders;

            header.Accept.Add(md);
            
           // header.Add("Accept", "application/xml");

            Uri uri = new Uri(getUrl);

            

            //Response Message
            Task<HttpResponseMessage> httpResponse= client1.GetAsync(uri);

            HttpResponseMessage responseMessage = httpResponse.Result;

            Console.WriteLine(responseMessage.ToString());
            
            //Status Code
            HttpStatusCode statusCode= responseMessage.StatusCode;

            Console.WriteLine("Status --> {0}",statusCode);

            Console.WriteLine("Status Code --> {0}", (int)statusCode);

            //Response Data
            HttpContent responseContent = responseMessage.Content;

            Task<string> responseBody = responseContent.ReadAsStringAsync();

            string data=responseBody.Result;

            Console.WriteLine("Response \n"+ data);

            client1.Dispose();
        }

        [Test]
        public void TestApiBySendAsyncMethod()
        {
            HttpRequestMessage rm = new HttpRequestMessage();
            rm.RequestUri = new Uri(getUrl);
            rm.Method = HttpMethod.Get;
            rm.Headers.Add("Accept", "application/json");

            HttpClient hc = new HttpClient();
            Task<HttpResponseMessage> hr= hc.SendAsync(rm);

            HttpResponseMessage responseMessage = hr.Result;

            Console.WriteLine(responseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = responseMessage.StatusCode;

            Console.WriteLine("Status --> {0}", statusCode);

            Console.WriteLine("Status Code --> {0}", (int)statusCode);

            //Response Data
            HttpContent responseContent = responseMessage.Content;

            Task<string> responseBody = responseContent.ReadAsStringAsync();

            string data = responseBody.Result;

            Console.WriteLine("Response \n" + data);

            hc.Dispose();
        }
    }
}
