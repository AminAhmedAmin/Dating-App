using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApI.Entiteis
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public byte[] PpasswordHash {get; set; }
         public byte[] PasswordSalt {get; set; }
       


        
    }
}