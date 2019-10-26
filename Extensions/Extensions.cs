using ag.DbData.Abstraction.Services;
using ag.DbData.DB2.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace ag.DbData.DB2.Extensions
{
    /// <summary>
    /// Represents <see cref="ag.DbData.DB2"/> extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Appends the registration of <see cref="DB2DbDataFactory"/> and <see cref="DB2DbDataObject"/> services to <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgDB2(this IServiceCollection services)
        {
            services.TryAddTransient<IDbDataStringProvider, DbDataStringProvider>();
            services.AddSingleton<IDB2DbDataFactory, DB2DbDataFactory>();
            services.AddTransient<DB2DbDataObject>();
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="DB2DbDataFactory"/> and <see cref="DB2DbDataObject"/> services to <see cref="IServiceCollection"/> and registers a configuration instance.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configurationSection">The <see cref="IConfigurationSection"/> being bound.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgDB2(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddAgDB2();
            services.Configure<DB2DbDataSettings>(opts =>
            {
                opts.AllowExceptionLogging = configurationSection.GetValue<bool>("AllowExceptionLogging");
                opts.ConnectionString = configurationSection.GetValue<string>("ConnectionString");
            });
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="DB2DbDataFactory"/> and <see cref="DB2DbDataObject"/> services to <see cref="IServiceCollection"/> and configures the options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureOptions">The action used to configure the options.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgDB2(this IServiceCollection services,
            Action<DB2DbDataSettings> configureOptions)
        {
            services.AddAgDB2();
            services.Configure(configureOptions);
            return services;
        }
    }
}
