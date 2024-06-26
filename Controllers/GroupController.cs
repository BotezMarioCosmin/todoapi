using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace todoapi_v00.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly GroupContext _context;
        public GroupsController(GroupContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Group>> GetGroup(long Id)
        {
            var group = await _context.Groups.FindAsync(Id);

            if (group == null)
            {
                return NotFound();
            }

            return group;
        }

        [HttpPost]
        public async Task<ActionResult<Group>> AddGroup(Group g)
        {
            _context.Groups.Add(g);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroup), new { id = g.id }, g);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> ModifyGroup(long Id, Group g)
        {
            if (Id != g.id)
            {
                return BadRequest();
            }
            _context.Entry(g).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> DeleteGroup(long Id)
        {
            var g = await _context.Groups.FindAsync(Id);
            if (g == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(g);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}