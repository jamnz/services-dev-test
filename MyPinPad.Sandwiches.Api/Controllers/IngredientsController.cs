using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Services;
using MyPinPad.Sandwiches.Api.Models;
using MyPinPad.Sandwiches.Api.Resources;

namespace MyPinPad.Sandwiches.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
[ApiVersion("1.1")]

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
        IActionResult response;
        try
        {
            var resources = _mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientResource>>(ingredients);
            response = Ok(resources) as IActionResult;
        }
        catch (KeyNotFoundException ex)
        {
            response = BadRequest();
        }
        return response;
    }
}