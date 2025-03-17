using Application.Interfaces;
using Application.Services;
using Autofac;
using Core.Interfaces;
using Infrastructure.Persistence;

namespace Presentation.AutofacModule
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register services
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
        }
    }
}
