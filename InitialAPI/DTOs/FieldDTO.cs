using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InitialAPI.DTOs
{
    public class FieldDTO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string? Content { get; set; }

        public long FormId { get; set; }
    }
}
