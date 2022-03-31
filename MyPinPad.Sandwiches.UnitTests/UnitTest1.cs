using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyPinPad.Sandwiches.Api.Controllers;
using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Services;
using MyPinPad.Sandwiches.Api.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyPinPad.Sandwiches.UnitTests
{
    public class IngredientsControllerTests
    {
        private readonly IngredientsController _controller;
        private readonly new Mock<IIngredientService> ingredientServiceMock;
        private readonly new Mock<IMapper> mapperMock;
        private List<Ingredient> items;


        public IngredientsControllerTests()
        {
            ingredientServiceMock = new Mock<IIngredientService>();
            //var cartItemMock = new Mock<Ingredient>();
            //cartItemMock.Setup(item => item.Name).Returns("tomato");

            items = new List<Ingredient>()
              {
                  new Ingredient{Name ="test tomato"}
              };
            ingredientServiceMock.Setup(c => c.List()).Returns(items.AsEnumerable());

            mapperMock = new Mock<IMapper>();
            _controller = new IngredientsController(ingredientServiceMock.Object, mapperMock.Object);
        }

        [Fact]
        public async void Test1()
        {
            // Act
            var okResult = await _controller.Get();
         
            // Assert
           
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        //[Fact]
        //public void GetById_ExistingGuidPassed_ReturnsOkResult()
        //{
        //    // Arrange
        //    //var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        //    // Act
        //    var okResult = _controller.Get();
        //    // Assert
        //    Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        //}
    }
}