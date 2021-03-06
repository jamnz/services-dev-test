using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Services;
using MyPinPad.Sandwiches.Api.Models;
using MyPinPad.Sandwiches.Api.Resources;

namespace MyPinPad.Sandwiches.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{

    private readonly IRecipeService _recipeService;
    private readonly IMapper _mapper;

    public RecipesController(IRecipeService recipeService, IMapper mapper)
    {
        _recipeService = recipeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string name)
    {               
        IActionResult response;

        try
        {
            var result = await _recipeService.GetByName(name);
            var recipeHashedResource = _mapper.Map<RecipeHashed, RecipeHashedResource>(result);
            response = Ok(recipeHashedResource) as IActionResult;
        }
        catch (KeyNotFoundException ex)
        {
            response = BadRequest(ex.Message);
        }

        return response;
    }

    //[HttpGet]
    //public async Task<IActionResult> GetByName(string name)
    //{
    //    var result = Ok(new GetRecipeResponse()) as IActionResult;
    //    return Ok(result);
    //}

    [HttpPost]

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateRecipeRequest request)
    {
        try
        {
            if (request == null)
            {
                return  BadRequest("CreateRecipeRequest object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            //additional code

            var recipe = _mapper.Map<CreateRecipeRequest, Recipe>(request);
            var result = await _recipeService.SaveAsync(recipe);

            //if (!result.Success)
            //{
            //    return BadRequest(new ErrorResource(result.Message));
            //}

            var recipeHashedResource = _mapper.Map<RecipeHashed, RecipeHashedResource>(result);
            return Ok(recipeHashedResource);

            return CreatedAtRoute("GetByName", new { name = request.Name });
        }
        catch (Exception ex)
        {
           //todo log this
            return StatusCode(500, "Internal server error");
        }
    }
}