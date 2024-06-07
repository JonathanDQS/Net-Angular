using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitialAPI.Models
{
    [Table("Form")]
    public class Form
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Description { get; set; }

        public virtual ICollection<Field> Fields { get; set; } = new List<Field>();
    }
}
