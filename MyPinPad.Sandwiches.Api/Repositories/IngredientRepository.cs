using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Repositories;

namespace MyPinPad.Sandwiches.Api.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        Task IIngredientRepository.AddAsync(Ingredient category)
        {
            throw new NotImplementedException();
        }

        Task<Ingredient> IIngredientRepository.FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Ingredient> IIngredientRepository.List()
        {
            return new List<Ingredient>()
            {
                {new Ingredient(){Id=1 , Name="tomato"} },
                 {new Ingredient(){Id=2 , Name="cheese"} },
                  {new Ingredient(){Id=3 , Name="butter"} },

            };
        }

        void IIngredientRepository.Remove(Ingredient category)
        {
            throw new NotImplementedException();
        }

        void IIngredientRepository.Update(Ingredient category)
        {
            throw new NotImplementedException();
        }
    }
}
