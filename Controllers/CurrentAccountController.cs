using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrentAccountController : ControllerBase
{

    private readonly ILogger<CurrentAccountController> _logger;

    public CurrentAccountController(ILogger<CurrentAccountController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCurrentAccount")]
    public CurrentAccount Get()
    {
       return new CurrentAccount{
            Balance = 100
       };
    }

}