using System.ComponentModel.DataAnnotations;
namespace MyPinPad.Hashing.Api.Models;

public class CreateHashRequest
{
    [Required]
    public string Message { get; set; }
    public string Salt { get; set; }
    [Required]
    [EnumDataType(typeof(HashingAlgoTypes))]
    public string Algorithm { get; set; }
}