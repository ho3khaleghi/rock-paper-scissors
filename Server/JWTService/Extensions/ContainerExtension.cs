using Autofac;
using Core.Kernel.Helper;

namespace JWTService.Extensions
{
    public static class ContainerExtension
    {
        public static ContainerBuilder RegisterJWTServiceDependencies(this ContainerBuilder builder) =>
            DependencyInjectionHelper.RegisterDependencyTypes(builder, "JWTService.dll", string.Empty);
    }
}
