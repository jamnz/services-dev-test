using System.ComponentModel.DataAnnotations;

namespace MyPinPad.Sandwiches.Api.Domain.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
