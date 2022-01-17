using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.API.Utility
{
    public class BaseProperty
    {
        [Column(Order = 0)]
        [Key]
        public Guid Id { get; set; }

        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        //[StringLength(50, MinimumLength=2)]
        //[ForeignKey("State_ID")]
        //
    }
}