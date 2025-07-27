using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class UsersController(IUserService _userService) : ApiBaseController
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var result = await _userService.RegisterAsync(registerDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var result = await _userService.LoginAsync(loginDto);
            return Ok(result);
        }
    }
}
