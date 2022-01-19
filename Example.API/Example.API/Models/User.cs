using Example.API.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Example.API.Models
{
    public partial class User : BaseProperty
    {
        [JsonIgnore]
        [ForeignKey("PositionID")]
        public Position Position { get; set; }

        [JsonIgnore]
        [ForeignKey("SchoolID")]
        public School School { get; set; }

        public Guid PositionID { get; set; }
        public Guid SchoolID { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        [JsonIgnore]
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public int Gender { get; set; }

        [MaxLength(200)]
        public string Bio { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(350)]
        public string? UserImage { get; set; }

        public string? Token { get; set; }
    }
}