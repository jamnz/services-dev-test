using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Repositories;
using MyPinPad.Sandwiches.Api.Domain.Services;

namespace MyPinPad.Sandwiches.Api.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IHashApi _hashApi;
        private readonly IMapper _mapper;

        private readonly IMemoryCache _cache;

        public RecipeService(IRecipeRepository productRepository, IHashApi categoryRepository,  IMemoryCache cache, IMapper mapper)
        {
            _recipeRepository = productRepository;
            _hashApi = categoryRepository;         
            _cache = cache;
            _mapper = mapper;
        }

        //public async Task<QueryResult<Recipe>> ListAsync(string name)
        //{
        //    // Here I list the query result from cache if they exist, but now the data can vary according to the category ID, page and amount of
        //    // items per page. I have to compose a cache to avoid returning wrong data.
        //    string cacheKey = GetCacheKeyForProductsQuery(query);

        //    var products = await _cache.GetOrCreateAsync(cacheKey, (entry) =>
        //    {
        //        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
        //        return _productRepository.ListAsync(query);
        //    });

        //    return products;
        //}
        public async Task<RecipeHashed> SaveAsync(Recipe recipe) 
        {
       
            var hash = await _hashApi.GetHash(recipe);

         
            var hashedRecipe = _mapper.Map<Recipe, RecipeHashed>(recipe);
            hashedRecipe.Hash = hash;

            await _recipeRepository.AddAsync(hashedRecipe);
            return hashedRecipe;

        }
    }
}
