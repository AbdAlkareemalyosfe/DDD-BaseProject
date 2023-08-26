using Microsoft.Extensions.DependencyInjection;
using Repositories.GeneralRepo;

namespace Repositories.RespoServices
{
    public static class RepoExtension
    {
        public static void AddMyServices(this IServiceCollection services)
        {

            services.AddTransient(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));
        }
    }
}