using MyPinPad.Sandwiches.Api.Domain.Models;

namespace MyPinPad.Sandwiches.Api.Domain.Repositories
{
    public interface IHashApi
    {
         Task<string> GetHash(Recipe recipe);
    }
}
