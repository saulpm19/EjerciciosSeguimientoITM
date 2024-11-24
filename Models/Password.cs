using System.ComponentModel.DataAnnotations;

namespace Ejercicios.Models
{

    public class Password
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}



