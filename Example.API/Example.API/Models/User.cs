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

        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }
    }
}