using BankingApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DatabaseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("migrate")]
        public IActionResult MigrateDatabase()
        {
            _context.Database.Migrate();
            return Ok("Database migration completed successfully.");
        }
    }
}
