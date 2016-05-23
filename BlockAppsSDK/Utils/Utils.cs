using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace BlockAppsSDK
{
    public static class Utils
    {

        public static async Task<string> getRequest(string url)
        {
            var httpClient = new HttpClient();
            string result = "";
            byte[] bytes = await httpClient.GetByteArrayAsync(url);
            result = Encoding.UTF8.GetString(bytes,0,bytes.Length);
            return result;
        }
    }
}
