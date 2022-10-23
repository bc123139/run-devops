using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.Client.Models;
using System.Diagnostics;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory,ILogger<HomeController> logger)
        {
            _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {

            var response = await _httpClient.GetAsync("product");
            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
            if(productList == null)
            {
                productList = new List<Product>()
                {
                    new Product
                    {
                        Description="Api doesnot call"
                    }
                };
            }
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}