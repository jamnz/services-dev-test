using MyPinPad.Sandwiches.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MyPinPad.Sandwiches.Api.Domain.Services;
using MyPinPad.Sandwiches.Api.Domain.Repositories;

namespace MyPinPad.Sandwiches.Api.Services
{
    public class IngredientService : IIngredientService
    {

        private readonly IIngredientRepository _ingredientRepository;

        private readonly IMemoryCache _cache;

        public IngredientService(IIngredientRepository ingredientRepository, IMemoryCache cache)
        {
            _ingredientRepository = ingredientRepository;

            _cache = cache;
        }

        Task IIngredientService.AddAsync(Ingredient category)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Ingredient> IIngredientService.List()
        {           
            var ingredients =  _cache.GetOrCreate(CacheKeys.IngerdientList, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _ingredientRepository.List();
            });

            return ingredients;
        }

      

    }
}

