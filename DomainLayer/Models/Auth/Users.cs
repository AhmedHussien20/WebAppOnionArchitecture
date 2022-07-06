using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models.Auth
{
    public class Users:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }    
    }
}
