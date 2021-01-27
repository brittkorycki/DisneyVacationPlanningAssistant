using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using VacationPlanningAssistant.Services;
using VacationPlanningAssistant.Contracts;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(DisneyVacationPlanningAssistant.Startup))]
namespace DisneyVacationPlanningAssistant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterType<TransportService>().As<ITransportService>();
            builder.RegisterType<AccommodationService>().As<IAccommodationService>();
            builder.RegisterType<DiningService>().As<IDiningService>();
            builder.RegisterType<TodayService>().As<ITodayService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            ConfigureAuth(app);
        }
    }
}
