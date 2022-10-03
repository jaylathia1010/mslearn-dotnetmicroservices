using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class PizzaReadDto
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public string Ingredients { get; set; }
        public int Cost { get; set; }
        public string InStock { get; set; }
    }
}