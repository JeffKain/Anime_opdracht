using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimeList_Project.Startup))]
namespace AnimeList_Project
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
