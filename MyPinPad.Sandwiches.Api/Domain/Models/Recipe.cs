namespace MyPinPad.Sandwiches.Api.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Ingredient Bread { get; set; }
        public IList<Ingredient> Ingredients { get; set; }
    }

    public class RecipeHashed : Recipe
    {
        public string Hash { get; set; }
    }
}
