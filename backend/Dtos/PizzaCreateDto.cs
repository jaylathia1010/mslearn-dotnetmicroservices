using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class PizzaCreateDto
    {
        [Required]
        public string PizzaName { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public string InStock { get; set; }
    }
}