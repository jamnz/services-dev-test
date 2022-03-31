using MyPinPad.Sandwiches.Api.Domain.Models;
using MyPinPad.Sandwiches.Api.Domain.Repositories;
using MyPinPad.Sandwiches.Api.Repositories.Models;
using Newtonsoft.Json;

namespace MyPinPad.Sandwiches.Api.Repositories
{
    public class HashApi : IHashApi
    {
        private readonly IConfiguration _configuration;
        public HashApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        async Task<string> IHashApi.GetHash(Recipe recipe)
        {
            var hashAlgorithm = _configuration["HashAlgorithm"];
            var hashSalt = _configuration["HashSalt"];
            var json = JsonConvert.SerializeObject(recipe);
            var createHashRequest = new CreateHashRequest() { Message = json, Algorithm = hashAlgorithm, Salt = hashSalt };
            using (var httpClient = new HttpClient())
            {
                JsonContent content = JsonContent.Create(createHashRequest);
                var hashApiUrl = _configuration["HashApiUrl"];
                var response = await httpClient.PostAsync(hashApiUrl, content);
                var responseObject = JsonConvert.DeserializeObject<CreateHashResponse>(await response.Content.ReadAsStringAsync());
                return responseObject.Hash;

            }
        }
    }
}
