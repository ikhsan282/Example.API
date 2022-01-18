using Example.API.Utility;
using System.ComponentModel.DataAnnotations;

namespace Example.API.Models
{
    public class School : BaseProperty
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }
    }
}