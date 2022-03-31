using MyPinPad.Sandwiches.Api.Domain.Models;

namespace MyPinPad.Sandwiches.Api.Domain.Repositories
{
    public interface IIngredientRepository
    {

        IEnumerable<Ingredient> List();
        Task AddAsync(Ingredient category);
        Task<Ingredient> FindByIdAsync(int id);
        void Update(Ingredient category);
        void Remove(Ingredient category);

    }
}
