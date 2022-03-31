using Microsoft.AspNetCore.Mvc;
using MyPinPad.Hashing.Api.Models;
using System.Security.Cryptography;
using System.Text;

namespace MyPinPad.Hashing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateHashController : ControllerBase
    {
       
        [HttpPost]
        [ProducesResponseType(typeof(CreateHashResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateHashRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

           // var result = Ok(new CreateHashResponse()) as IActionResult;
            var hash = ComputeHash(request);
            return Ok(new CreateHashResponse { Hash= hash });
        }

        public static string ComputeHash(CreateHashRequest request)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(request.Message+request.Salt);
            using (var algorithm = System.Security.Cryptography.HashAlgorithm.Create(request.Algorithm))
            {
                Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
                return BitConverter.ToString(hashedBytes).Replace("-", "");
            }        
        }
       
    }
}