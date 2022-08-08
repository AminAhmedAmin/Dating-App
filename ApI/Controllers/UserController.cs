using ApI.Data;
using ApI.Entiteis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApI.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly DataContext context;

        public UsersController(DataContext _context)
        {
            context = _context;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task <ActionResult<IEnumerable<AppUser>>> getusers()
            {
             return await context.Users.ToListAsync();
                
            }


        [Authorize]
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> getuser( int id)
        {
            return  await context.Users.FindAsync(id);
             
        }



    }
}
