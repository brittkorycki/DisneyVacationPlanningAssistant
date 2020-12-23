using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DisneyVacationPlanningAssistant.Startup))]
namespace DisneyVacationPlanningAssistant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
