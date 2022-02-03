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

namespace Example.API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService service;

        public UsersController(PancaAppContext db, IConfiguration iconf, IHttpContextAccessor contextAccessor)
        {
            string auth = contextAccessor.HttpContext.Request.Headers["Authorization"];
            string email = auth == string.Empty ? string.Empty : db.getUserUsername(auth);
            service = new UserService(db, email, contextAccessor, iconf);
        }

        [HttpGet]
        public async Task<ActionResult> getAllData()
        {
            try
            {
                var result = await service.getAllData();
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

        [HttpGet]
        [Route("me")]
        public async Task<ActionResult> getUserMe()
        {
            try
            {
                var result = await service.getUserMe();
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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> getDataById(Guid id)
        {
            try
            {
                var result = await service.getDataById(id);
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
        [Route("upload-image")]
        public async Task<ActionResult> postImage(IFormFile uploadImage)
        {
            try
            {
                var result = await service.postImage(uploadImage);
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

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> putData(Guid id, UserViewModel request)
        {
            try
            {
                var result = await service.putData(id, request);
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> deleteData(Guid id)
        {
            try
            {
                var result = await service.deleteData(id);
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
    }
}