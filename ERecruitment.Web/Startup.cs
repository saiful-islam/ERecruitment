using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERecruitment.Web.Startup))]
namespace ERecruitment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
