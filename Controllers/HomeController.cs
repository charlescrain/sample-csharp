using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNet.Mvc;

namespace BlockApps.Net.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient _client = new HttpClient();
            //Insert URL for API 
            Task<string> AsycnApiRequest = apiRequest("http://jsonplaceholder.typicode.com/posts/1", _client);

            //These are async requests so you use "await" to wait for the async request to finish
            string json = await AsycnApiRequest;
            //dynamic ApiResponse = System.Web.Helpers.Json.Decode(json);

            //Viewbag is essentially a way for you to put any object onto the front end

            ViewBag.data = await Account.Get("307976d54fc4634be31bcbe5b5595e193fe1d447");
            return View();
        }

         async Task<string> apiRequest(string url, HttpClient client)
        {
            string result = "";
            byte[] bytes = await client.GetByteArrayAsync(url);
            result = System.Text.Encoding.UTF8.GetString(bytes);
            return result;
        }
    }

    public class Account 
    {
        public string ContractRoot { get; set; }

        public string Kind { get; set; }

        public string Balance { get; set; }
       

        public string Address { get; set; }

        public string LatestBlockNum { get; set; }
        
        public string LatestBlockId { get; set; }
        

        public string Code { get; set; }

        static public async Task<List<Account>> Get(string address)
        {
            var _client =  new HttpClient();
            var url = "http://strato-dev2.blockapps.net/eth/v1.0/account?address=" + address;
            var request = getRequest(url, _client);
            var response = await request;
            //response = response.Substring(1,response.Length-2);
            Console.Write(response);
            return JsonConvert.DeserializeObject<List<Account>>(response);

        }

        private static async Task<string> getRequest(string url, HttpClient client)
        {
            string result = "";
            byte[] bytes = await client.GetByteArrayAsync(url);
            result = System.Text.Encoding.UTF8.GetString(bytes);
            return result;
        }
    }
}
