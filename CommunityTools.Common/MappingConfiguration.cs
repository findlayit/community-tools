using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace CommunityTools.Common
{
    public class MappingConfiguration
    {
        public static void Configure(Assembly assembly, IMapperConfiguration cfg)
        {
            GetProfiles(assembly).ToList().ForEach(x => cfg.AddProfile((Profile)Activator.CreateInstance(x)));
        }

        private static IEnumerable<Type> GetProfiles(Assembly assembly)
        {
            return assembly.GetTypes().Where(type => !type.IsAbstract && typeof(Profile).IsAssignableFrom(type));
        }
    }
}