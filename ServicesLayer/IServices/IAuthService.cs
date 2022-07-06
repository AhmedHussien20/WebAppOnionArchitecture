using BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IServices
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginDTO loginDTO);
    }
}
