using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kursach;
using Newtonsoft.Json;
using Kursach.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Kursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        public readonly ArishDbContext _dbContext;


        public TestsController()
        {
            ArishDbContext dbContext = new ArishDbContext();

            _dbContext = dbContext;
        }
        [HttpGet("allTests")]
        public async Task<ActionResult<IEnumerable<Test>>> GetTests()
        {

            var tests = await _dbContext.Tests.Include(t => t.Questions).ThenInclude(q => q.Answers).ToListAsync();


            if (tests == null)
            {
                return Ok(null);
            }
            return Ok(tests);
        }
        // GET: api/Tests
        [HttpGet("userTests/{userId}")]
        public async Task<ActionResult<IEnumerable<Test>>> GetUserTests(int userId)
        {

            var tests = await (from test in _dbContext.Tests where test.UserId == userId select test).Include(t => t.Questions ).ThenInclude(q => q.Answers).ToListAsync();

          
            if (tests == null)
            {
                return Ok(null);
            }
            return Ok(tests);
        }

        // GET: api/Tests/5
        [HttpGet("{testId}")]
        public async Task<ActionResult<Test>> GetTest(int testId)
        {
         
            var test = await _dbContext.Tests.FindAsync(testId);

            if (test == null)
            {
                return Ok(null);
            }

            return Ok();
        }

        // PUT: api/Tests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(int id)
        {
            var reader = new StreamReader(Request.Body);

            var rawMessage = await reader.ReadToEndAsync();

            await Console.Out.WriteLineAsync(rawMessage);

            Test test = JsonConvert.DeserializeObject<Test>(rawMessage);

          
            var removetest = await _dbContext.Tests.FindAsync(id);
            _dbContext.Tests.Remove(removetest);
            await _dbContext.SaveChangesAsync();

            _dbContext.Tests.AddAsync(test);

            await _dbContext.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Tests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Test>> PostTest()
        {

            var reader = new StreamReader(Request.Body);

            var rawMessage = await reader.ReadToEndAsync();

           

            Test test = JsonConvert.DeserializeObject<Test>(rawMessage);

            await _dbContext.Tests.AddAsync(test);
            await _dbContext.SaveChangesAsync();
            return Ok(test);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            if (_dbContext.Tests == null)
            {
                return NotFound();
            }
            var test = await _dbContext.Tests.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _dbContext.Tests.Remove(test);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool TestExists(int id)
        {
            return (_dbContext.Tests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
