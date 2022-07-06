using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DTOs
{
    public class LoginDTO
    {
        public string userName { get; set; }
        public string password { get; set; }
    }

    public class LoginResponse
    {
        public string AccessToken { get; set; }
    }
}
