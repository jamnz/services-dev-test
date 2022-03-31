using MyPinPad.Sandwiches.Api.Domain.Models;

namespace MyPinPad.Sandwiches.Api.Domain.Services
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> List();
        Task AddAsync(Ingredient category);
    }
}