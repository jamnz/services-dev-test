using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Repositories;
using Newtonsoft.Json;

namespace MyPinPad.Sandwiches.Api.Repositories
{
   public class HashApi : IHashApi
   {
        async Task<string> IHashApi.GetHash(Recipe recipe) {
            var json = JsonConvert.SerializeObject(recipe);
            var createHashRequest  = new CreateHashRequest() { Message = json, Algorithm = "SHA1", Salt = "salty"};
            using (var httpClient = new HttpClient())
            {
                JsonContent content = JsonContent.Create(createHashRequest);
                var response = await httpClient.PostAsync("https://localhost:7214/CreateHash", content);
                var responseObject = JsonConvert.DeserializeObject<CreateHashResponse>(await response.Content.ReadAsStringAsync());
                return responseObject.Hash;
                
            }
        }     
    }
}
public class CreateHashRequest
{    
    public string Message { get; set; }
    public string Salt { get; set; } 
    public string Algorithm { get; set; }
}
public class CreateHashResponse
{
    public string Hash { get; set; }
   
}
