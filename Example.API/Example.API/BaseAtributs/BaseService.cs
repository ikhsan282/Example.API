using AutoMapper;
using Example.API.Models;
using Example.API.ViewModels;
using Microsoft.IdentityModel.Tokens;
using MyPhotos.API.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Example.API.Utility
{
    public abstract class BaseService
    {
        public Mapper mapper;
        public Guid newGuid = new Guid();
        private Dictionary<string, string> dictionaryList = new Dictionary<string, string>();
        public PancaAppContext db = new PancaAppContext();
        public ResponseModel result = new ResponseModel();
        public IConfiguration configuration;
        public User baseUser = new User();
        public IHttpContextAccessor contextAccessor;

        public BaseService(PancaAppContext db, string email, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            try
            {
                this.db = db;
                this.mapper = new Mapper(config);
                this.contextAccessor = contextAccessor;
                this.configuration = configuration;
                baseUser = db.Users.Where(a => a.Username == email).FirstOrDefault();
            }
            catch { }
        }

        #region CheckUsrLogin

        public bool checkUsrLogin()
        {
            bool result = baseUser.Token == null ? true : false;
            return result;
        }

        #endregion CheckUsrLogin

        #region ResponseAPI

        public static void response(ResponseModel response, int code, object? data = null, string? message = null)
        {
            response.Code = code;
            response.Data = data;
            response.Message = message;
        }

        #endregion ResponseAPI

        #region Env

        private string jwtKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["Key"];
        private string jwtIssuer = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["Issuer"];
        private string jwtAudience = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["Audience"];

        #endregion Env

        #region GetJwt

        public Dictionary<string, string> getJWT(User us)
        {
            var claim = new[] { new Claim("Email", us.Username) };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var Sign = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(3600);
            var Token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claims: claim,
                expires: expires,
                signingCredentials: Sign);

            dictionaryList.Add("expires_in", expires.ToString());
            dictionaryList.Add("signature", new JwtSecurityTokenHandler().WriteToken(Token));

            return dictionaryList;
        }

        #endregion GetJwt

        #region DefaultServices

        public abstract Task<ResponseModel> getAllData();

        public abstract Task<ResponseModel> getDataById(Guid id);

        public abstract Task<ResponseModel> postData(object request);

        public abstract Task<ResponseModel> putData(Guid id, Object request);

        public abstract Task<ResponseModel> deleteData(Guid id);

        #endregion DefaultServices

        #region GetUrl

        public string getUrlUserImages()
        {
            return contextAccessor.HttpContext.Request.Scheme + "://" + contextAccessor.HttpContext.Request.Host.Value + "/user-images/";
        }

        #endregion GetUrl

        #region Mapper

        private MapperConfiguration config = new MapperConfiguration(cfg =>
             {
                 cfg.AllowNullCollections = true;
                 cfg.AllowNullDestinationValues = true;
                 cfg.CreateMap<User, UserViewModel>().ReverseMap();
             });

        #endregion Mapper
    }
}