using Microsoft.Extensions.DependencyInjection;
using Oqtane.Core.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Oqtane.Shared.Extensions
{
    public static class StartupExtentions
    {
        public static IServiceCollection RegisterModulesAndThemes(this IServiceCollection services)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            DirectoryInfo folder = new DirectoryInfo(path);
            List<Assembly> moduleassemblies = new List<Assembly>();

            // iterate through Oqtane module assemblies in /bin ( filter is narrow to optimize loading process )
            foreach (FileInfo file in folder.EnumerateFiles("*.Module.*.dll"))
            {
                // check if assembly is already loaded
                Assembly assembly = assemblies.Where(item => item.Location == file.FullName).FirstOrDefault();
                if (assembly == null)
                {
                    // load assembly from stream to prevent locking file ( as long as dependencies are in /bin they will load as well )
                    assembly = AssemblyLoadContext.Default.LoadFromStream(new MemoryStream(File.ReadAllBytes(file.FullName)));
                }
            }
            
            // iterate through Oqtane theme assemblies in /bin ( filter is narrow to optimize loading process )
            foreach (FileInfo file in folder.EnumerateFiles("*.Theme.*.dll"))
            {
                // check if assembly is already loaded
                Assembly assembly = assemblies.Where(item => item.Location == file.FullName).FirstOrDefault();
                if (assembly == null)
                {
                    // load assembly from stream to prevent locking file ( as long as dependencies are in /bin they will load as well )
                    assembly = AssemblyLoadContext.Default.LoadFromStream(new MemoryStream(File.ReadAllBytes(file.FullName)));
                }
            }

            // dynamically register module services, contexts, and repository classes
            assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(item => item.FullName.StartsWith("Oqtane.") || item.FullName.Contains(".Module.")).ToArray();
            foreach (Assembly assembly in assemblies)
            {
                Type[] implementationtypes = assembly.GetTypes()
                    .Where(item => item.GetInterfaces().Contains(typeof(IService)))
                    .ToArray();
                foreach (Type implementationtype in implementationtypes)
                {
                    Type servicetype = Type.GetType(implementationtype.AssemblyQualifiedName.Replace(implementationtype.Name, "I" + implementationtype.Name));
                    if (servicetype != null)
                    {
                        services.AddScoped(servicetype, implementationtype); // traditional service interface
                    }
                    else
                    {
                        services.AddScoped(implementationtype, implementationtype); // no interface defined for service
                    }
                }
            }

            return services;
        }
    }
}
