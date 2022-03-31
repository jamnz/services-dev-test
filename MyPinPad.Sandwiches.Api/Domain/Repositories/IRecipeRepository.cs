using MyPinPad.Sandwiches.Api.Domain.Models;

namespace MyPinPad.Sandwiches.Api.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task AddAsync(RecipeHashed hashedRecipe);
        Task<RecipeHashed> FindByNameAsync(string name);
    }
}
