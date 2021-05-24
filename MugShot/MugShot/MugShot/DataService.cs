using MugShot.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MugShot
{
    public class DataService
    {
        public static async Task<Root> GetRecord(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(queryString);

            Root data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Root>(response);
                return data;
            }
            return null;
        }
    }
}
