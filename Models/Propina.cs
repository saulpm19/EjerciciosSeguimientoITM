using System.ComponentModel.DataAnnotations;

namespace Ejercicios.Models
{
    public class Propina
    {
        public int Id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal MontoTotal { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100")]
        public decimal PorcentajePropina { get; set; }

        public decimal MontoPropina  { get; set; }

        public decimal MontoTotalConPropina { get; set; }

        public Propina()
        {
            MontoPropina=(MontoTotal* PorcentajePropina)/100;
            MontoTotalConPropina=MontoTotal + MontoPropina;
        }

        
    }
}

