using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradoCeroV1.Models
{
    public class Alabanza
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; } = null!;
        [Required]
        [MaxLength(100, ErrorMessage = "El autor no puede exceder los 100 caracteres")]
        public string Autor { get; set; } = null!;
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Cuerpo { get; set; } = null!;
        public bool Modo { get; set; }
    }
}
