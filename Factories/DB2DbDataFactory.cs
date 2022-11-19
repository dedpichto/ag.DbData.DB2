using ag.DbData.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using IBM.Data.DB2.Core;

namespace ag.DbData.DB2.Factories
{
    /// <summary>
    /// Represents DB2DbDataFactory object.
    /// </summary>
    internal class DB2DbDataFactory : IDB2DbDataFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates object of type <see cref="DB2DbDataObject"/>.
        /// </summary>
        /// <returns><see cref="DB2DbDataObject"/> implementation of <see cref="IDbDataObject"/> interface.</returns>
        public IDbDataObject Create()
        {
            var dbObject = _serviceProvider.GetService<DB2DbDataObject>();
            return dbObject;
        }

        /// <summary>
        /// Creates object of type <see cref="DB2DbDataObject"/>.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        /// <returns><see cref="DB2DbDataObject"/> implementation of <see cref="IDbDataObject"/> interface.</returns>
        public IDbDataObject Create(string connectionString)
        {
            var dbObject = _serviceProvider.GetService<DB2DbDataObject>();
            dbObject.Connection = new DB2Connection(connectionString);
            return dbObject;
        }

        /// <summary>
        /// Creates object of type <see cref="DB2DbDataObject"/>.
        /// </summary>
        /// <param name="defaultCommandTimeOut">Replaces default coommand timeout of provider</param>
        /// <returns></returns>
        public IDbDataObject Create(int defaultCommandTimeOut)
        {
            var dbObject = _serviceProvider.GetService<DB2DbDataObject>();
            dbObject.DefaultCommandTimeout = defaultCommandTimeOut;
            return dbObject;
        }

        /// <summary>
        /// Creates new DB2DbDataFactory object.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        public DB2DbDataFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
