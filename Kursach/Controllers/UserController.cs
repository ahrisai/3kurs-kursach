using Kursach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Kursach.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ArishDbContext _dbContext;

        public UserController(ArishDbContext dbContext)
        {
            _dbContext = dbContext;
          
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
              if (_dbContext.IsDatabaseConnected())
            {
                Console.WriteLine("База данных подключена.");
            }
            else
            {
                Console.WriteLine("Не удалось подключиться к базе данных.");
            }
            var users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
