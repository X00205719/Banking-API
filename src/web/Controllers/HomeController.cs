using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Banking.Models;

namespace Banking.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public Task<ActionResult> Index()
    {
         using (HttpClient client = new HttpClient())
         {
            HttpResponseMessage response = await client.GetAsync("http://localhost:5053/api/BankAccounts");
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
