using AutoMapper;
using Example.API.Models;
using Example.API.Utility;
using Example.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using MyPhotos.API.Utilities;
using System.Text.Json;

namespace Example.API.Services
{
    public class UserService : BaseService
    {
        public UserService(PancaAppContext db, string email, IHttpContextAccessor contextAccessor, IConfiguration configuration) : base(db, email, contextAccessor, configuration)
        {
        }

        public override async Task<ResponseModel> deleteData(Guid id)
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var checkUser = await db.Users.FirstOrDefaultAsync(a => a.Id == id);

            if (checkUser == null)
            {
                response(result, 404, message: "User Id not found");
            }

            db.Users.Remove(checkUser);
            await db.SaveChangesAsync();

            response(result, 200);
            return result;
        }

        public override async Task<ResponseModel> getAllData()
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var users = await db.Users.Include(a => a.Position).Include(a => a.School).ToListAsync();
            var jsonString = JsonSerializer.Serialize(users);
            var jsonResult = JsonSerializer.Deserialize<List<User>>(jsonString);

            foreach (var item in jsonResult)
            {
                item.UserImage = getUrlUserImages() + item.UserImage;
            }

            response(result, 200, data: jsonResult);
            return result;
        }

        public override async Task<ResponseModel> getDataById(Guid id)
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var checkUser = await db.Users.Include(a => a.Position).Include(a => a.School).FirstOrDefaultAsync(a => a.Id == id);

            if (checkUser == null)
            {
                response(result, 404, message: "User Id not found");
            }

            checkUser.UserImage = getUrlUserImages() + checkUser.UserImage;

            response(result, 200, data: checkUser);
            return result;
        }

        public override async Task<ResponseModel> postData(object request)
        {
            if (checkUsrLogin()) response(result, 401, message: "Unauthorized"); return result;

            return result;
        }

        public override async Task<ResponseModel> putData(Guid id, object request)
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var jsonRequest = JsonSerializer.Serialize(request);
            var json = JsonSerializer.Deserialize<UserViewModel>(jsonRequest);

            if (json.Id != json.Id) response(result, 400, message: "Id in path & request must be same"); return result;

            var updateUser1 = await db.Users.FirstOrDefaultAsync(a => a.Id == json.Id) == null ? test("hehe") : null;
            var updateUser = await db.Users.FirstOrDefaultAsync(a => a.Id == json.Id);
            var checkUsernameExist = await db.Users.FirstOrDefaultAsync(u => u.Username == json.Username);
            var checkPosition = await db.Positions.FirstOrDefaultAsync(a => a.Id == json.PositionID);
            var checkSchool = await db.Schools.FirstOrDefaultAsync(a => a.Id == json.SchoolID);

            if (updateUser == null) response(result, 404, message: "UserId not found"); return result;
            if (checkUsernameExist != null) response(result, 409, message: "Username already exist"); return result;
            if (checkPosition == null) response(result, 404, message: "PositionId not found"); return result;
            if (checkSchool == null) response(result, 404, message: "SchoolId not found"); return result;

            response(result, 204, message: "Successfully updated User");
            return result;
        }

        private string test(string message)
        {
            return null;
        }

        public async Task<ResponseModel> postImage(IFormFile request)
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }
            return result;
        }

        public async Task<ResponseModel> getUserMe()
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var checkUser = await db.Users.Include(a => a.Position).Include(a => a.School).FirstOrDefaultAsync(a => a.Id == baseUser.Id);

            if (checkUser == null)
            {
                response(result, 404, message: "User not found");
            }

            checkUser.UserImage = getUrlUserImages() + checkUser.UserImage;
            response(result, 200, data: checkUser);
            return result;
        }
    }
}