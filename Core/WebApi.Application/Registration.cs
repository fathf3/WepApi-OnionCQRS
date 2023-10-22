﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Bases;
using WebApi.Application.Exceptions;

namespace WebApi.Application
{
    public  static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddTransient<ExceptionMiddleWare>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();

            foreach (var item in types)
            {
                services.AddTransient(item);
            }
            return services;

        }

    }
}
