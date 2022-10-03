using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class PizzaInfo
    {
        [Key]
        [Required]
        public int Id { get; set; }

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
