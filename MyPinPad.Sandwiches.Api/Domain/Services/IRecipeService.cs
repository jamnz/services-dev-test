using MyPinPad.Sandwiches.Api.Domain.Models;

namespace MyPinPad.Sandwiches.Api.Domain.Services
{
    public interface IRecipeService
    {
        Task<RecipeHashed> SaveAsync(Recipe recipe);
        Task<RecipeHashed> GetByName(string name);
    }
}