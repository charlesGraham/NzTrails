using Microsoft.AspNetCore.Identity;

namespace NzTrails.Api.Repositories.Interfaces
{
    public interface ITokenRepo
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
