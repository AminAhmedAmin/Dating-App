using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApI.Entiteis;

namespace ApI.interfaces
{
    public interface ITokenService
    {
         string CreateToken (AppUser user) ;
    }
}