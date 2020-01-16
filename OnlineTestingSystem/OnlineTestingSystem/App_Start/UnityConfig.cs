using OnlineTestingSystem.Interfaces;
using OnlineTestingSystem.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace OnlineTestingSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();


            // register all your components with the container here
            container.RegisterType<IUsers, UsersModel>();
            container.RegisterType<IAdmin, AdminModel>();
            container.RegisterType<IDiscipline, DisciplineModel>();
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}