namespace MyPinPad.Sandwiches.Api.Resources
{
    public class RecipeHashedResource
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IngredientResource Bread { get; set; }
        public IList<IngredientResource> Ingredients { get; set; }
        public string Hash { get; set; }

    }
}
