using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kursach;
using Kursach.Models;
using Newtonsoft.Json;

namespace Kursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly ArishDbContext _context;

        public ResultsController()
        {
            ArishDbContext dbContext = new ArishDbContext();
            _context = dbContext;
        }

        // GET: api/Results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetResults()
        {
          if (_context.Results == null)
          {
              return Ok(null);
          }
            return await _context.Results.Include(r=>r.UserAnswers).Include(r=>r.Test).ThenInclude(t=>t.Questions).ThenInclude(q=>q.Answers).ToListAsync();
        }

        // GET: api/Results/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetResult(int id)
        {
            var results = await (from result in _context.Results where result.UserId==id select result).Include(r=>r.UserAnswers).ToListAsync() ;
            if (results == null)
            {
                return Ok(null);
            }
            

            return Ok(results);
        }

        // PUT: api/Results/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResult(int id, Result result)
        {
            if (id != result.Id)
            {
                return BadRequest();
            }

            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Results
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("UserResult")]
        public async Task<ActionResult<Result>> PostResult()
        {
            var reader = new StreamReader(Request.Body);

            var rawMessage = await reader.ReadToEndAsync();

            await Console.Out.WriteLineAsync(  rawMessage );

            Result result = JsonConvert.DeserializeObject<Result>(rawMessage);
           await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();

            return Ok(result);
        }

        // DELETE: api/Results/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            if (_context.Results == null)
            {
                return NotFound();
            }
            var result = await _context.Results.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Results.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultExists(int id)
        {
            return (_context.Results?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
