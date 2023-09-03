using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Model;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Model.UserDto.Request;

namespace PascoliTesteAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        IConfiguration _configuration;

        public UserController(IUserServices userServices, IConfiguration configuration)
        {
            _userServices = userServices;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequestDto user)
        {
            try
            {
                bool result = await _userServices.CreateAsync(user);
                if (result)
                    return Ok(result);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
        // PUT api/user
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserRequestDto user)
        {
            try
            {
                bool result = await _userServices.UpdateAsync(user);
                if (result)
                    return Ok();
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        //DELETE api/user
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] Guid userid)
        {
            bool result = await _userServices.DeleteAsync(userid);
            if (result)
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        // GET api/user
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<User> users = await _userServices.GetAllAsync();
            return Ok(users);
        }

        // GET api/user/{id}
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            UserResponseDto user = await _userServices.GetByIdAsync(id);
            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

    }
}
