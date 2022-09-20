using AutoMapper;
using DelsaMovie.Data;
using DelsaMovie.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DelsaMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;



        public AccountController(UserManager<ApiUser> userManager,
            
            ILogger<AccountController> logger,
            IMapper mapper)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] ApiUserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attemp for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                var user =_mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    foreach(var err in result.Errors)
                    {
                        ModelState.TryAddModelError(err.Code,err.Description);

                    }
                    return BadRequest($"User Registration Attemp Failed");

                    
                }
                return Accepted();


            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");

                return Problem($"Something Went Wrong in the {nameof(Register)}",statusCode:500);
            }

        }

        /*[HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login Attemp for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userDTO.Email,userDTO.Passwrod,false,false);
                if (!result.Succeeded)
                {
                    return Unauthorized(userDTO);
                    
                }
                return Accepted();


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");

                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }


        }
*/
    }
}
