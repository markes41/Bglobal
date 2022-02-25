using System.Net.Http;
using System.Threading.Tasks;

namespace Bglobal.Web.Helpers
{
    public class ApiHelper
    {
        public async static Task<string> GetRequest(string url)
        {
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(url))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        } 
    }
}
