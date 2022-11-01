using Newtonsoft.Json;
using NUnitExampleProject.Model;
using NUnitExampleProject.Model.JsonModel;
using OpenQA.Selenium.DevTools.V102.Debugger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace NUnitExampleProject.GetEndPoint
{
    internal class TestGetEndPoint
    {
        private string getUrl = "https://reqres.in/api/users/2";
        private string getAllUserUrl = "https://reqres.in/api/users";
        HttpClient? client;



        [Test, Order(1)]
        public void TestApiByStringURL()
        {
            client = new HttpClient();
            client.GetAsync(getUrl);
            client.Dispose();
        }

        [Test, Order(2)]
        public void TestApiByUriMethod()
        {
            MediaTypeWithQualityHeaderValue md = new MediaTypeWithQualityHeaderValue("application/xml");
            HttpClient client1 = new HttpClient();

            HttpRequestHeaders header = client1.DefaultRequestHeaders;

            header.Accept.Add(md);

            // header.Add("Accept", "application/xml");

            Uri uri = new Uri(getUrl);

            //Response Message
            Task<HttpResponseMessage> httpResponse = client1.GetAsync(uri);

            HttpResponseMessage responseMessage = httpResponse.Result;

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

            client1.Dispose();
        }

        [Test,Order(3)]
        public void TestApiBySendAsyncMethod()
        {
            HttpRequestMessage rm = new HttpRequestMessage();
            rm.RequestUri = new Uri(getUrl);
            rm.Method = HttpMethod.Get;
            rm.Headers.Add("Accept", "application/json");

            HttpClient hc = new HttpClient();
            Task<HttpResponseMessage> hr = hc.SendAsync(rm);

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

        [Test, Order(4)]
        public void TestApiResponseByModel()
        {
            HttpRequestMessage rm = new HttpRequestMessage();
            rm.RequestUri = new Uri(getUrl);
            rm.Method = HttpMethod.Get;
            rm.Headers.Add("Accept", "application/json");

            HttpClient hc = new HttpClient();
            Task<HttpResponseMessage> hr = hc.SendAsync(rm);

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

            RestResponse rr = new RestResponse((int)statusCode, data);

            Console.WriteLine(rr.ToString());

            hc.Dispose();
        }

        [Test, Order(5)]
        public void TestDeserializeByJsonResponse()
        {
            HttpRequestMessage rm = new HttpRequestMessage();
            rm.RequestUri = new Uri(getUrl);
            rm.Method = HttpMethod.Get;
            rm.Headers.Add("Accept", "application/json");

            HttpClient hc = new HttpClient();
            Task<HttpResponseMessage> hr = hc.SendAsync(rm);

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

            RestResponse rr = new RestResponse((int)statusCode, data);

            Console.WriteLine(rr.ToString());

            Root rt = JsonConvert.DeserializeObject<Root>(rr.ResponseData);

            if (rr.StatusCode == 200)
            {
                Console.WriteLine("id : " + rt.data.id.ToString());
                Console.WriteLine("email : " + rt.data.email.ToString());
                Console.WriteLine("firstName : " + rt.data.first_name.ToString());
                Console.WriteLine("Avatar : " + rt.data.avatar.ToString());
                Console.WriteLine("lastName : " + rt.data.last_name.ToString());
                Console.WriteLine("url : " + rt.support.url.ToString());
                Console.WriteLine("text : " + rt.support.text.ToString());
            }
            else
            {
                Console.WriteLine("Status code is not 200");
            }


            hc.Dispose();
        }

        [Test, Order(6)]
        public void TestDeserializeByJsonResponseList()
        {
            HttpRequestMessage rm = new HttpRequestMessage();
            rm.RequestUri = new Uri(getAllUserUrl);
            rm.Method = HttpMethod.Get;
            rm.Headers.Add("Accept", "application/json");

            HttpClient hc = new HttpClient();
            Task<HttpResponseMessage> hr = hc.SendAsync(rm);

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

            RestResponse rr = new RestResponse((int)statusCode, data);

            Console.WriteLine(rr.ToString());

            var model = JsonConvert.DeserializeObject<RootList>(rr.ResponseData);

            // List<RootList> rt = JsonConvert.DeserializeObject<List<RootList>>(rr.ResponseData);

            if (rr.StatusCode == 200)
            {
                for (int i = 0; i < Convert.ToInt32(model.per_page.ToString()); i++)
                {
                    Console.WriteLine("First Name: {0} || Last Name: {1} || Email: {2}", model.data[i].first_name.ToString(), model.data[i].last_name.ToString(), model.data[i].email.ToString());
                }
            }
            hc.Dispose();
        }

        [Test, Order(7)]
        public void TestDeserializeByXMLList()
        {
            HttpRequestMessage rm = new HttpRequestMessage();
            rm.RequestUri = new Uri(getAllUserUrl);
            rm.Method = HttpMethod.Get;
            rm.Headers.Add("Accept", "application/json");

            HttpClient hc = new HttpClient();
            Task<HttpResponseMessage> hr = hc.SendAsync(rm);

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

            RestResponse rr = new RestResponse((int)statusCode, data);

            Console.WriteLine(rr.ToString());
            
            //Converted a Json Response to XML
            XmlDocument doc = JsonConvert.DeserializeXmlNode(rr.ResponseData,"root");
            
            //Fetch Node by Tag Name 
            XmlNodeList dataValue = doc.GetElementsByTagName("data");

            //printed inner text of specified node position filter by data
            Console.WriteLine("Inner String for data at 2nd list {0}",dataValue[2].InnerText.ToString());
            Console.WriteLine("Email of inner XML {0}", dataValue[2].InnerXml.ToString());

            //Printing all values through iteration
            for (int i = 0; i < dataValue.Count; i++)
            {
                Console.WriteLine("Iteration +"+i+" "+dataValue[i].InnerXml);
                //Fetching child Node data below
                Console.WriteLine("Child Node Item Value at 1st position ie Email : {0} ",dataValue[i].ChildNodes.Item(1).InnerText.Trim());
            }
            hc.Dispose();
        }
       
    }
}
