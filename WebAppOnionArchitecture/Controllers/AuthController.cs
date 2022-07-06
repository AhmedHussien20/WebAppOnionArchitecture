using BusinessLayer.DTOs;
using BusinessLayer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppOnionArchitecture.Helper;

namespace WebAppOnionArchitecture.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Property
        private readonly IAuthService _AuthService;
        #endregion

        #region Constructor
        public AuthController(IAuthService AuthService)
        {
            _AuthService = AuthService;
        }
        #endregion

        #region FieldForce Login
        /// <summary>
        /// Login User for Access 
        /// </summary>
        /// <remarks>This Api check this user Exist or not </remarks>  
        /// <response code="200">Retrieves AccessToken </response>
        /// <response code="404">User Don't have Access .</response>

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO userForLoginDto) 
        {
            var response = new BaseResponse();
            try
            { 
                var token=await _AuthService.Login(userForLoginDto);
                return Ok( token );
            }
            catch (System.Exception ex)
            {
                response.ErrorList.Add(ex.Message);
                return BadRequest(response);
            }
            
        }
        #endregion
    }
}
