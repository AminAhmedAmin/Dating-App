using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApI.Data;
using ApI.DTO;
using ApI.Entiteis;
using ApI.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApI.Controllers
{
    public class AccountController :BaseApiController
    {
        private readonly DataContext context;
    private readonly ITokenService tokenService;

    public AccountController (DataContext _context ,ITokenService  _tokenService )
        {
            context = _context;
      tokenService = _tokenService ;
    }

         [HttpPost("register")]
        public async Task <ActionResult<UserDto>> Register( Registerdto registerdto)
            {

             if( await UserExists(registerdto.Username))return BadRequest("user name is tacken");

             
             using var hmac = new HMACSHA512();
             var user =new AppUser
             {
                UserName= registerdto.Username.ToLower(),
                PpasswordHash =  hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.Password)),
                PasswordSalt= hmac.Key
              };

             context.Users.Add(user);
             await context.SaveChangesAsync();
             return new UserDto
             {
                   Username= user.UserName,
                   Tocken= tokenService.CreateToken(user)
             };
               
            }



               [HttpPost("Login")]

            public async Task <ActionResult<UserDto>> Login( LoginDto loginDto)
            {

                 var user =await context.Users.SingleOrDefaultAsync(x =>x.UserName==loginDto.Username );
                 if(user ==null) return Unauthorized("invalid user name");
                 using  var hmac = new HMACSHA512(user.PasswordSalt);
                 var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                 for(int i =0; i<ComputeHash.Length ;i++)
                 {
                    if (ComputeHash[i] != user.PpasswordHash[i] ) return Unauthorized("invalid user password");
                 }

                 return new UserDto
             {
                   Username= user.UserName,
                   Tocken= tokenService.CreateToken(user)
             };
            }




            public async Task<bool> UserExists(string username){
                return await context.Users.AnyAsync(x=>x.UserName==username.ToLower());
            }
    }                               
}