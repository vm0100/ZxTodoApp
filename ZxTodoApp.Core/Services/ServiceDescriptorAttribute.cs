using System;
using Microsoft.Extensions.DependencyInjection;

namespace ZxTodoApp.Core;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ServiceDescriptorAttribute(string serviceKey, Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Transient) : Attribute
{
    public ServiceDescriptorAttribute(Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Transient) : this(null, serviceType, lifetime)
    {
    }

    public Type ServiceType { get; } = serviceType;

    public ServiceLifetime Lifetime { get; } = lifetime;

    public string ServiceKey { get; } = serviceKey;
}