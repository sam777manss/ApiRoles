using ApiRoles;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel loginModel)
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.BaseAddress = new Uri("https://localhost:7140/api/Authenticate/login");

                //HTTP POST
                var response = await client.PostAsJsonAsync("", loginModel); // Pass the loginModel as the request body

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the response content to TokenResponseModel
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponseModel>(responseContent);
                    var token = tokenResponse.Token;
                    var expiration = tokenResponse.Expiration;

                    TempData["Token"] = token;
                    TempData["Expiration"] = expiration;

                    return RedirectToAction("TokenAuth");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();
        }
        [HttpGet]
        public IActionResult TokenAuth()
        {
            string token = TempData["Token"] as string;
            DateTime? expiration = TempData["Expiration"] as DateTime?;
            if(token!= null)
            {
                TokenResponseModel viewModel = new TokenResponseModel
                {
                    Token = token,
                    Expiration = expiration ?? DateTime.Now.AddHours(3)
                };
                return View(viewModel);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TokenAuth(TokenResponseModel tokenResponseModel)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:7140");
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Set the Authorization header with the bearer token
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponseModel.Token);

                // HTTP POST
                var response = await client.GetAsync("WeatherForecast"); // Pass the tokenResponseModel as the request body
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseContent);
                if (response.IsSuccessStatusCode)
                {
                    // Success logic here
                    return View();
                }
                else
                {
                    // Error handling logic here
                    return View(tokenResponseModel);
                }
            }
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