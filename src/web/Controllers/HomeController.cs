using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Banking.Models;
using Newtonsoft.Json;

namespace Banking.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<ActionResult> Index()
    {
        string apiUrl = _configuration["ApiSettings:BaseUrl"];

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl + "/api/BankAccounts");
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();
                var bankAccounts = JsonConvert.DeserializeObject<List<BankAccount>>(responseContent);

                return View("Index", bankAccounts);
            }

        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
