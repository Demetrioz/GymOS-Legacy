using GymOS.DataModel.Models.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GymOS.DataModel.Contexts
{
    public class GymOSContext : ApiAuthorizationDbContext<GymOSUser>
    {
        public GymOSContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions
        ) : base(options, operationalStoreOptions)
        {
        }
    }
}
