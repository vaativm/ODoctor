using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ODoctor.Infrastructure.Identity
{
    public class ODoctorIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ODoctorUser> userManager)
        {
            var defaultUser = new ODoctorUser { UserName = "admin@odoctor.com", Email = "admin@odoctor.com", PhoneNumber = "0715095433" };
            await userManager.CreateAsync(defaultUser, "P@ssw0rd1");
        }
    }
}
