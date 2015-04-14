using System.Reflection;
using System.Web.Mvc;
using SampleEntityFramework.DataAccess;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace SampleEntityFramework.SchoolWeb
{
    public static class DependencyInjectionConfig
    {
        public static void Configure()
        {
            var container = new Container();

            container.Register<ISchoolContext, SchoolContext>();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();

            var resolver = new SimpleInjectorDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
        }
    }
}