using Example.API.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace MyPhotos.API.Utilities
{
    public class PancaAppContext : DbContext
    {
        private readonly string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["db"];

        private class UserInfoLogin
        { public string Email { get; set; } }

        public string getUserUsername(string token)
        {
            try
            {
                if (token != null)
                {
                    var bearer = new JwtSecurityToken(token.Replace("Bearer", "").Trim());
                    var payload = JsonSerializer.Serialize(bearer.Payload);
                    var retult = JsonSerializer.Deserialize<UserInfoLogin>(payload);
                    return retult.Email;
                }
            }
            catch { }

            return null;
        }

        public PancaAppContext()
        {
        }

        public PancaAppContext(DbContextOptions<PancaAppContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}