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


        async Task<RecipeHashed> IRecipeService.SaveAsync(Recipe recipe)
        {
       
            var hash = await _hashApi.GetHash(recipe);

         
            var hashedRecipe = _mapper.Map<Recipe, RecipeHashed>(recipe);
            hashedRecipe.Hash = hash;

            await _recipeRepository.AddAsync(hashedRecipe);
            return hashedRecipe;

        }

        async Task<RecipeHashed> IRecipeService.GetByName(string name)
        {
            return await _recipeRepository.FindByNameAsync(name);
        }

       
    }
}
