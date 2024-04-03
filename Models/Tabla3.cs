using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TEST.Models
{
    public class Tabla3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [MaybeNull]
        public string Campo1 { get; set; } = string.Empty;
        [MaxLength(100)]
        [MaybeNull]
        public string Campo2 { get; set; } = string.Empty;
        [MaxLength(100)]
        [MaybeNull]
        public string Campo3 { get; set; } = string.Empty;
    }
}
