using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Services;
using MyPinPad.Sandwiches.Api.Models;
using MyPinPad.Sandwiches.Api.Resources;

namespace MyPinPad.Sandwiches.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientService _ingredientsService;
    private readonly IMapper _mapper;

    public IngredientsController(IIngredientService ingredientsService, IMapper mapper)
    {
        _ingredientsService = ingredientsService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<IngredientResource>), 200)]
    public async Task<IActionResult> Get()
    {
        var ingredients = _ingredientsService.List();
        var resources = _mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientResource>>(ingredients);


        var result = Ok(resources) as IActionResult;
        //  var result = Ok(new GetIngredientsResponse()) as IActionResult;
        return result;
    }
}