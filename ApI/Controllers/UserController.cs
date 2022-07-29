using ApI.Data;
using ApI.Entiteis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;

        public UserController(DataContext _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task <ActionResult<IEnumerable<AppUser>>> getusers()
            {
             var users = await context.Users.ToListAsync();
            return Ok(users);    
            }



        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> getuser( int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(e => e.Id == id);
            return Ok(user);
        }



    }
}
