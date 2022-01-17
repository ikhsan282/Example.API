using Example.API.Models;
using Example.API.Utility;
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
            User delete = await db.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (delete == null)
            {
                response(result, 204, message: "User not found");
                return result;
            }
            //await db.Users.Remove(delete);

            return result;
        }

        public override async Task<ResponseModel> getAllData()
        {
            response(result, 200, data: await db.Users.Select(a => a).ToListAsync());
            return result;
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
    }
}