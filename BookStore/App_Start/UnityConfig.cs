using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using DataAccessLayer;
using BookGateway;
using BookGatewayService;

namespace BookStore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IBookGateway, Paypal>();
            container.RegisterType<IBookGateway, StripNet>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}