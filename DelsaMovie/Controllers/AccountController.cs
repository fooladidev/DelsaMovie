﻿using AutoMapper;
using DelsaMovie.Data;
using DelsaMovie.Models;
using DelsaMovie.Services;
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
        private readonly IAuthManager _authManager;



        public AccountController(UserManager<ApiUser> userManager,
            
            ILogger<AccountController> logger,
            IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
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
                var result = await _userManager.CreateAsync(user,userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach(var err in result.Errors)
                    {
                        ModelState.TryAddModelError(err.Code,err.Description);

                    }
                    return BadRequest($"User Registration Attemp Failed");

                    
                }
                await _userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();


            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");

                return Problem($"Something Went Wrong in the {nameof(Register)}",statusCode:500);
            }

        }

        [HttpPost]
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
                if (!await _authManager.ValidateUser(userDTO))
                {
                    return Unauthorized(userDTO);

                }
                return Accepted(new {Token = await _authManager.CreateToken()});


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");

                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }


        }

    }
}
