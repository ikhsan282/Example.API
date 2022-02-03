using Example.API.Models;
using Example.API.Utility;
using Example.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using MyPhotos.API.Utilities;

namespace Example.API.Services
{
    public class AuthService : BaseService
    {
        public AuthService(PancaAppContext db, string email, IHttpContextAccessor contextAccessor, IConfiguration configuration) : base(db, email, contextAccessor, configuration)
        {
        }

        public async Task<ResponseModel> postAuth(AuthViewModel request)
        {
            var check = await db.Users.FirstOrDefaultAsync(a => a.Username == request.Username && a.Password == Public.encryptPassword(request.Password));

            if (check == null)
            {
                response(result, 404, message: "Invalid Username or Password");
                return result;
            }

            var data = getJWT(check);

            check.Token = data["signature"];
            Public.TOKEN = check.Token;

            await db.SaveChangesAsync();
            response(result, 200, data: data);
            return result;
        }

        public async Task<ResponseModel> postSignUp(UserViewModel request)
        {
            var check = await db.Users.FirstOrDefaultAsync(a => a.Username == request.Username);
            var checkPosition = await db.Positions.FirstOrDefaultAsync(a => a.Id == request.PositionID);
            var checkSchool = await db.Schools.FirstOrDefaultAsync(a => a.Id == request.SchoolID);

            if (check != null)
            {
                response(result, 409, message: "Username already exist!");
                return result;
            }

            if (checkPosition == null)
            {
                response(result, 404, message: "PositionId not found");
                return result;
            }

            if (checkSchool == null)
            {
                response(result, 404, message: "SchoolId not found");
                return result;
            }

            User add = mapper.Map<User>(request);
            add.Password = Public.encryptPassword(add.Password);
            add.UserImage = "default-user-image.png";

            await db.Users.AddAsync(add);
            await db.SaveChangesAsync();

            response(result, 201, data: add);

            return result;
        }

        public async Task<ResponseModel> Logout()
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var user = await db.Users.FirstOrDefaultAsync(x => x.Token == Public.TOKEN);

            if (user != null)
            {
                Public.TOKEN = string.Empty;
                user.Token = null;
                await db.SaveChangesAsync();
                response(result, 200, "Successfully Logout");
            }
            return result;
        }

        #region Base

        public override Task<ResponseModel> deleteData(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<ResponseModel> getAllData()
        {
            throw new NotImplementedException();
        }

        public override Task<ResponseModel> getDataById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<ResponseModel> postData(object request)
        {
            throw new NotImplementedException();
        }

        public override Task<ResponseModel> putData(Guid id, object request)
        {
            throw new NotImplementedException();
        }

        #endregion Base
    }
}