using Kursach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Kursach.Controllers
{
    
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        public readonly ArishDbContext _dbContext;

        public UserController()
        {
            ArishDbContext dbContext = new ArishDbContext();
            
                _dbContext = dbContext;
            

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            
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
    } }

