using AutoMapper;
using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Models;
using MyPinPad.Sandwiches.Api.Resources;

namespace MyPinPad.Sandwiches.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Ingredient, IngredientResource>();
            CreateMap<CreateRecipeRequest, Recipe>();
            CreateMap<RecipeHashed, RecipeHashedResource>();
            CreateMap<Recipe, RecipeHashed>();
        }
    }
}
