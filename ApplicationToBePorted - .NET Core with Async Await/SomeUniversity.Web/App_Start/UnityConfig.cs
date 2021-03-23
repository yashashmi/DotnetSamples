using SomeUniversity.Data;
using SomeUniversity.Service;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;

namespace SomeUniversity
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<SchoolContext, SchoolContext>(new InjectionConstructor("SchoolContext"));
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IStudentService, StudentService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }


    }
}