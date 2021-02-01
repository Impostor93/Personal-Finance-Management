using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceManagement.Domain.Shared;

namespace PersonalFinanceManagement.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services, Assembly assembly)
        {
            var repositories = GetAllTypesImplementingOpenGenericType(typeof(IRepository<,>), assembly);

            foreach (var repository in repositories)
            {
                var repoInterface = repository.GetInterfaces().FirstOrDefault(e => IsAssignableToGenericType(e, typeof(IRepository<,>)));
                services.AddScoped(repoInterface, repository);
            }
        }

        public static System.Collections.Generic.IEnumerable<Type> GetAllTypesImplementingOpenGenericType(Type openGenericType, Assembly assembly)
        {
            var allRepoTypes = from x in assembly.GetTypes()
                               from z in x.GetInterfaces()
                               let y = x.BaseType
                               where
                               (y != null && y.IsGenericType &&
                               openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition())) ||
                               (z.IsGenericType &&
                               openGenericType.IsAssignableFrom(z.GetGenericTypeDefinition()))
                               select x;

            return allRepoTypes.Where(e => e.IsAbstract == false);
        }
        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();
            if (interfaceTypes.Count() == 0)
                return false;

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            Type baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }
    }
}