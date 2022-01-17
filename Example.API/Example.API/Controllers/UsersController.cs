using Example.API.Services;
using Example.API.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyPhotos.API.Utilities;
using System;
using System.Threading.Tasks;

namespace Example.API.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    [ApiController]
    public class UsersController : BaseController
    {
        private PancaAppContext db;
        private UserService userService;

        public UsersController(PancaAppContext db, IConfiguration iconf, IHttpContextAccessor contextAccessor)
        {
            string auth = contextAccessor.HttpContext.Request.Headers["Authorization"];
            string email = auth == string.Empty ? string.Empty : db.getUserUsername(auth);
            userService = new UserService(db, email, contextAccessor, iconf);
        }

        [HttpGet]
        public override async Task<ActionResult> getAllData()
        {
            try
            {
                var result = await userService.getAllData();
                if (result.Code == StatusCodes.Status404NotFound) return NotFound(result);
                if (result.Code == StatusCodes.Status409Conflict) return NotFound(result);
                if (result.Code == StatusCodes.Status400BadRequest) return NotFound(result);
                if (result.Code == StatusCodes.Status204NoContent) return NotFound(result);
                if (result.Code == StatusCodes.Status500InternalServerError) return NotFound(result);
                if (result.Code == StatusCodes.Status201Created) return NotFound(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public override async Task<ActionResult> getDataById(Guid id)
        {
            try
            {
                var result = await userService.getDataById(id);
                if (result.Code == StatusCodes.Status404NotFound) return NotFound(result);
                if (result.Code == StatusCodes.Status409Conflict) return NotFound(result);
                if (result.Code == StatusCodes.Status400BadRequest) return NotFound(result);
                if (result.Code == StatusCodes.Status204NoContent) return NotFound(result);
                if (result.Code == StatusCodes.Status500InternalServerError) return NotFound(result);
                if (result.Code == StatusCodes.Status201Created) return NotFound(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public override async Task<ActionResult> postData(object request)
        {
            try
            {
                var result = await userService.postData(request);
                if (result.Code == StatusCodes.Status404NotFound) return NotFound(result);
                if (result.Code == StatusCodes.Status409Conflict) return NotFound(result);
                if (result.Code == StatusCodes.Status400BadRequest) return NotFound(result);
                if (result.Code == StatusCodes.Status204NoContent) return NotFound(result);
                if (result.Code == StatusCodes.Status500InternalServerError) return NotFound(result);
                if (result.Code == StatusCodes.Status201Created) return NotFound(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public override async Task<ActionResult> putData(Guid id, object request)
        {
            try
            {
                var result = await userService.putData(id, request);
                if (result.Code == StatusCodes.Status404NotFound) return NotFound(result);
                if (result.Code == StatusCodes.Status409Conflict) return NotFound(result);
                if (result.Code == StatusCodes.Status400BadRequest) return NotFound(result);
                if (result.Code == StatusCodes.Status204NoContent) return NotFound(result);
                if (result.Code == StatusCodes.Status500InternalServerError) return NotFound(result);
                if (result.Code == StatusCodes.Status201Created) return NotFound(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public override async Task<ActionResult> deleteData(Guid id)
        {
            try
            {
                var result = await userService.deleteData(id);
                if (result.Code == StatusCodes.Status404NotFound) return NotFound(result);
                if (result.Code == StatusCodes.Status409Conflict) return NotFound(result);
                if (result.Code == StatusCodes.Status400BadRequest) return NotFound(result);
                if (result.Code == StatusCodes.Status204NoContent) return NotFound(result);
                if (result.Code == StatusCodes.Status500InternalServerError) return NotFound(result);
                if (result.Code == StatusCodes.Status201Created) return NotFound(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}