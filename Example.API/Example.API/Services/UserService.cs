using Example.API.Models;
using Example.API.Utility;
using Example.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using MyPhotos.API.Utilities;

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

            var delete = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (delete == null)
            {
                response(result, 204, message: "User not found");
                return result;
            }
            db.Users.Remove(delete);
            await db.SaveChangesAsync();
            return result;
        }

        public override async Task<ResponseModel> getAllData()
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var data = await (from a in db.Users
                              join b in db.Positions
                              on a.PositionID equals b.Id
                              join c in db.Schools
                              on a.SchoolID equals c.Id
                              select new
                              {
                                  a.Id,
                                  a.FirstName,
                                  a.LastName,
                                  a.Username,
                                  a.Bio,
                                  a.DateOfBirth,
                                  a.Gender,
                                  UserImage = getUrlUserImages() + a.UserImage,
                                  a.CreatedBy,
                                  a.ModifiedBy,
                                  a.CreatedDate,
                                  a.ModifiedDate,
                                  a.Position,
                                  a.School
                              }).ToListAsync();
            response(result, 200, data: data);
            return result;
        }

        public async Task<ResponseModel> getUserMe()
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var data = await (from a in db.Users
                              join b in db.Positions
                              on a.PositionID equals b.Id
                              join c in db.Schools
                              on a.SchoolID equals c.Id
                              where a.Id == baseUser.Id
                              select new
                              {
                                  a.Id,
                                  a.FirstName,
                                  a.LastName,
                                  a.Username,
                                  a.Bio,
                                  a.DateOfBirth,
                                  a.Gender,
                                  UserImage = getUrlUserImages() + a.UserImage,
                                  a.CreatedBy,
                                  a.ModifiedBy,
                                  a.CreatedDate,
                                  a.ModifiedDate,
                                  a.Position,
                                  a.School
                              }).FirstOrDefaultAsync();
            response(result, 200, data: data);
            return result;
        }

        public override async Task<ResponseModel> getDataById(Guid id)
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var data = await (from a in db.Users
                              join b in db.Positions
                              on a.PositionID equals b.Id
                              join c in db.Schools
                              on a.SchoolID equals c.Id
                              where a.Id == id
                              select new
                              {
                                  a.Id,
                                  a.FirstName,
                                  a.LastName,
                                  a.Username,
                                  a.Bio,
                                  a.DateOfBirth,
                                  a.Gender,
                                  UserImage = getUrlUserImages() + a.UserImage,
                                  a.CreatedBy,
                                  a.ModifiedBy,
                                  a.CreatedDate,
                                  a.ModifiedDate,
                                  a.Position,
                                  a.School
                              }).FirstOrDefaultAsync();
            response(result, 200, data: data);
            return result;
        }

        public override async Task<ResponseModel?> postData(object request)
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

        public override Task<ResponseModel> putData(Guid id, UserViewModel request)
        {
            if (checkUsrLogin())
            {
                response(result, 401, message: "Unauthorized");
                return result;
            }

            var check = await db.Users.Where(a => a.Username == request.Username).FirstOrDefaultAsync();
            var checkPosition = await db.Positions.Where(a => a.Id == request.PositionID).FirstOrDefaultAsync();
            var checkSchool = await db.Schools.Where(a => a.Id == request.SchoolID).FirstOrDefaultAsync();

            if (check != null)
            {
                response(result, 409, message: "Username already exist!");
                return result;
            }

            if (checkPosition == null)
            {
                response(result, 404, message: "PositionID not found");
                return result;
            }

            if (checkSchool == null)
            {
                response(result, 404, message: "SchoolID not found");
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
    }
}