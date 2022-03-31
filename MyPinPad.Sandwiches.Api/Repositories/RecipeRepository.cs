using Microsoft.Extensions.Caching.Memory;
using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Repositories;

namespace MyPinPad.Sandwiches.Api.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IMemoryCache _cache;
        public RecipeRepository( IMemoryCache cache)
        {
            _cache = cache;
        }
        async Task IRecipeRepository.AddAsync(RecipeHashed hashedRecipe)
        {
            var cacheKey = "Recipe_" + hashedRecipe.Name;
            _cache.Set(cacheKey, hashedRecipe);
        }

        async Task<RecipeHashed> IRecipeRepository.FindByNameAsync(string name)
        {
            var cacheKey = "Recipe_" + name;
            RecipeHashed cachedHashedRecipe;
            if (_cache.TryGetValue(cacheKey, out cachedHashedRecipe))
            {
                return cachedHashedRecipe;
            }
            throw new KeyNotFoundException($"Expected recipe for  {name} not found.");
           
        }
    }
}
