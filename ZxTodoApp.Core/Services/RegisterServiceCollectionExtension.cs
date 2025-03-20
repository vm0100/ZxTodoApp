using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ZxTodoApp.Core;

public static class RegisterServiceCollectionExtension
{
    public static IServiceCollection RegisterAttributeServices(this IServiceCollection services)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().AsParallel())
        foreach (var typeInfo in assembly.DefinedTypes.AsParallel())
        foreach (var attr in typeInfo.GetCustomAttributes<ServiceDescriptorAttribute>())
            services.Add(new ServiceDescriptor(attr.ServiceType, attr.ServiceKey, typeInfo.AsType(), attr.Lifetime));

        return services;
    }
}