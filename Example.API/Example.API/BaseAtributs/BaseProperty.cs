using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.API.Utility
{
    public class BaseProperty
    {
        [Column(Order = 0)]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? CreatedBy { get; set; } = new Guid();
        public Guid? ModifiedBy { get; set; } = new Guid();
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        // [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        //[StringLength(50, MinimumLength=2)]
        //[ForeignKey("State_ID")]
        //
    }
}