using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kursach;
using Kursach.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace Kursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ArishDbContext _context;

        public GroupsController()
        {
            ArishDbContext dbContext = new ArishDbContext();

           
            _context = dbContext;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
          if (_context.Groups == null)
          {
              return Ok();
          }
            return await _context.Groups.ToListAsync();
        }
        [HttpGet("members")]
        public async Task<ActionResult<IEnumerable<GroupUser>>> GetMembers()
        {
            if (_context.GroupUsers == null)
            {
                return Ok();
            }
            return await _context.GroupUsers.ToListAsync();
        }
        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
          if (_context.Groups == null)
          {
              return NotFound();
          }
            var @group = await _context.Groups.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group @group)
        {
            if (id != @group.Id)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup()
        {
            var reader = new StreamReader(Request.Body);

            var rawMessage = await reader.ReadToEndAsync();

            await Console.Out.WriteLineAsync(rawMessage);

            Group group = JsonConvert.DeserializeObject<Group>(rawMessage);

            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            return Ok(group);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
           
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool GroupExists(int id)
        {
            return (_context.Groups?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost("Join/{GroupId}/{UserId}")]
        public async Task<ActionResult<Group>> JoinGroup(int groupId,int userId)
        {
            GroupUser groupUser = new GroupUser();
            groupUser.GroupId=groupId;
            groupUser.UserId = userId;


            await _context.GroupUsers.AddAsync(groupUser);
            await _context.SaveChangesAsync();
            return Ok(groupUser);
        }

        [HttpDelete("Leave/{GroupId}/{UserId}")]
        public async Task<ActionResult<Group>> LeaveGroup(int groupId, int userId)
        {



            GroupUser groupUser =  _context.GroupUsers.FirstOrDefault(gu => gu.GroupId == groupId&& gu.UserId == userId);
            
             _context.GroupUsers.Remove(groupUser);
            await _context.SaveChangesAsync();
            return Ok(groupUser);
        }

        [HttpPost("Test/{GroupId}/{TestId}")]
        public async Task<ActionResult<Group>> AddTestToGroup(int groupId, int testId)
        {
            GroupTest groupTest = new GroupTest();
            groupTest.GroupId = groupId;
            groupTest.TestId = testId;


            await _context.GroupTests.AddAsync(groupTest);
            await _context.SaveChangesAsync();
            return Ok(groupTest);
        }

        [HttpDelete("Test/{GroupId}/{TestId}")]
        public async Task<ActionResult<Group>> RemoveTestFromGroup(int groupId, int testId)
        {



            GroupTest testUser = _context.GroupTests.FirstOrDefault(gu => gu.GroupId == groupId && gu.TestId == testId);

            _context.GroupTests.Remove(testUser);
            await _context.SaveChangesAsync();
            return Ok(testUser);
        }
        [HttpGet("GroupTests")]
        public async Task<ActionResult<GroupTest>> GetGroupTests()
        {

            var groupTest = await _context.GroupTests.ToListAsync();
            return Ok(groupTest);




        }
    }
}
