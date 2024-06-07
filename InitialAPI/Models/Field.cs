using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitialAPI.Models
{
    [Table("Field")]
    public class Field
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        [Required]
        [StringLength(64)]
        public string Type { get; set; }

        [StringLength(64)]
        public string? Content { get; set; }
        
        [ForeignKey("Form")]
        public long FormId { get; set; }

        public virtual Form? Form { get; set; }
    }
}
