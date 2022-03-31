using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Services;
using MyPinPad.Sandwiches.Api.Models;
using MyPinPad.Sandwiches.Api.Resources;

namespace MyPinPad.Sandwiches.Api.Controllers.V2;

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
    [MapToApiVersion("2.0")]
    [ProducesResponseType(typeof(IEnumerable<IngredientResource>), 200)]
    public async Task<IActionResult> Get()
    {
        //note for vesioning the new version would call new Services or operations
        var ingredients = _ingredientsService.List();
        var resources = _mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientResource>>(ingredients);

        var result = Ok(resources) as IActionResult;
        return result;
    }
}