using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data.Interfaces;
using API.IdentityFolder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class IdentityAccountController : BaseAPIController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        public IdentityAccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) !=null;
        }

        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x=> x.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(email);

            return new UserDTO{
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] LoginDTO loginDTO){
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if(user == null)
            {
                return BadRequest();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if(!result.Succeeded)
            {
                return Unauthorized();
            }
            return new UserDTO
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };


        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] RegisterDTO registerDTO){
            
                var createdUser = new AppUser {  
                    UserName = registerDTO.DisplayName,
                    DisplayName = registerDTO.DisplayName,
                    Email = registerDTO.Email
                };

                var result = await _userManager.CreateAsync(createdUser,registerDTO.Password);

                if(!result.Succeeded) return BadRequest();

                return new UserDTO{
                    DisplayName = createdUser.DisplayName,
                    Token= _tokenService.CreateToken(createdUser),
                    Email = createdUser.Email
                };
            
        }


        
    }
}