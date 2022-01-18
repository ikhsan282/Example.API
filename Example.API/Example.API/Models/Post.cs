using Example.API.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Example.API.Models
{
    public partial class Post : BaseProperty
    {
        [JsonIgnore]
        [ForeignKey("UserID")]
        public User User { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public long ViewCount { get; set; }
        public long ReportCount { get; set; }
        public long LikeCount { get; set; }

        [MaxLength(350)]
        public string? PostImage { get; set; }
    }
}