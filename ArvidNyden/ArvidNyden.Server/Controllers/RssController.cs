using ArvidNyden.Server.Configuration;
using ArvidNyden.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArvidNyden.Server.Controllers
{
    [Route("api/[controller]")]
    public class RssController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiUrl;

        public RssController(IOptions<ApiSettings> settings)
        {
            apiUrl = settings.Value.ApiUrl;
        }

        [HttpGet("[action]")]
        public async Task<RssList> List()
        {
            var stringContent = await client.GetStringAsync(apiUrl);
            var rssList = JsonConvert.DeserializeObject<RssList>(stringContent);

            return rssList;
        }
    }
}
