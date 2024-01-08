using Kursach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;


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

        [HttpPost("post")]
        public async Task<ActionResult<User>> SetUser()
        {
            var reader = new StreamReader(Request.Body);

            var rawMessage = await reader.ReadToEndAsync();

            await Console.Out.WriteLineAsync(rawMessage);

            User user= JsonConvert.DeserializeObject<User>(rawMessage);

            await _dbContext.Users.AddAsync(user);
           await _dbContext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut()]
        public async Task<ActionResult<User>> PutGroup(int id)
        {
            var reader = new StreamReader(Request.Body);

            var rawMessage = await reader.ReadToEndAsync();

            await Console.Out.WriteLineAsync(rawMessage);

            User user = JsonConvert.DeserializeObject<User>(rawMessage);

          

            _dbContext.Entry(user).State = EntityState.Modified;

           
                await _dbContext.SaveChangesAsync();
            
          

            return Ok();
        }
    } }

