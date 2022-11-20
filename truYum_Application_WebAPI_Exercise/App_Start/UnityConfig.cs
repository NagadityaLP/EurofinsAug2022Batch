using System.Web.Mvc;
using truYum_Application_WebAPI_Exercise.Models.Data;
using Unity;
using Unity.Mvc5;

namespace truYum_Application_WebAPI_Exercise
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<IMenuItemRepository, MenuItemRepository>();
            container.RegisterType<IOrderItemRepository, OrderItemRepository>();
        }
    }
}