using Example.API.Services;
using Example.API.Utilities;
using Example.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyPhotos.API.Utilities;
using System;
using System.Threading.Tasks;

namespace Example.API.BaseAtributs
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthService service;

        public AuthController(PancaAppContext db, IConfiguration iconf, IHttpContextAccessor contextAccessor)
        {
            string auth = contextAccessor.HttpContext.Request.Headers["Authorization"];
            string email = auth == string.Empty ? string.Empty : db.getUserUsername(auth);
            service = new AuthService(db, email, contextAccessor, iconf);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> postAuth(AuthViewModel request)
        {
            try
            {
                var result = await service.postAuth(request);
                if (result.Code == StatusCodes.Status404NotFound) return NotFound(result);
                if (result.Code == StatusCodes.Status409Conflict) return Conflict(result);
                if (result.Code == StatusCodes.Status400BadRequest) return BadRequest(result);
                if (result.Code == StatusCodes.Status204NoContent) return NoContent();
                if (result.Code == StatusCodes.Status500InternalServerError) return StatusCode(500, result);
                if (result.Code == StatusCodes.Status201Created) return Created("localhost", result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("sign-up")]
        public async Task<ActionResult> postSignUp(UserViewModel request)
        {
            try
            {
                var result = await service.postSignUp(request);
                if (result.Code == StatusCodes.Status404NotFound) return NotFound(result);
                if (result.Code == StatusCodes.Status409Conflict) return Conflict(result);
                if (result.Code == StatusCodes.Status400BadRequest) return BadRequest(result);
                if (result.Code == StatusCodes.Status204NoContent) return NoContent();
                if (result.Code == StatusCodes.Status500InternalServerError) return StatusCode(500, result);
                if (result.Code == StatusCodes.Status201Created) return Created("localhost", result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult> getLogout()
        {
            try
            {
                var result = await service.Logout();
                if (result.Code == StatusCodes.Status401Unauthorized) return Unauthorized(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}