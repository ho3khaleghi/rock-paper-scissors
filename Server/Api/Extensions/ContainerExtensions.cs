using Autofac;
using Core.Kernel.Helper;

namespace RockPaperScissors.Api.Extensions
{
    public static class ContainerExtension
    {
        public static ContainerBuilder RegisterRPSDependencies(this ContainerBuilder builder) =>
            DependencyInjectionHelper.RegisterDependencyTypes(builder, "RockPaperScissors.*.dll", "RockPaperScissors.Api.dll");
    }
}
