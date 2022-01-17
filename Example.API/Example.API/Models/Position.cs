using Example.API.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Example.API.Models
{
    public partial class Position : BaseProperty
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}