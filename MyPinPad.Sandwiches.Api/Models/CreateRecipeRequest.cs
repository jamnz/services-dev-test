using MyPinPad.Sandwiches.Api.Domain.Models;

namespace MyPinPad.Sandwiches.Api.Models;

public class CreateRecipeRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Ingredient Bread { get; set; }
    public   IList<Ingredient> Ingredients { get; set; }
}