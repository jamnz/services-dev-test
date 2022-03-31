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
        private readonly IConfiguration _configuration;

        public RecipeService(IRecipeRepository productRepository, IHashApi categoryRepository, IConfiguration configuration, IMapper mapper)
        {
            _recipeRepository = productRepository;
            _hashApi = categoryRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        async Task<RecipeHashed> IRecipeService.SaveAsync(Recipe recipe)
        {
            var hashedRecipe = _mapper.Map<Recipe, RecipeHashed>(recipe);

            var useRecipeHash = _configuration.GetValue<bool>("HashAlgorithm");
            if (useRecipeHash)
            {
                var hash = await _hashApi.GetHash(recipe);
                hashedRecipe.Hash = hash;
            }

            await _recipeRepository.AddAsync(hashedRecipe);
            return hashedRecipe;
        }

        async Task<RecipeHashed> IRecipeService.GetByName(string name)
        {
            return await _recipeRepository.FindByNameAsync(name);
        }       
    }
}
