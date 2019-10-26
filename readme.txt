***************************************************************************************************

ATTENTION! THIS PACKAGE IS BUILT WITH x64 ARCHITECTURE AS PLATFORM TARGET AS IT IS A REQUIREMENT OF
IBM.Data.DB2.Core dependency

***************************************************************************************************

// add section to settings file (optional)
{
  "DB2DbDataSettings": {
    "AllowExceptionLogging": false, // optional, default is "true"
    "ConnectionString": "YOUR_CONNECTION_STRING" // optional
  }
}

***************************************************************************************************

// add appropriate usings
using ag.DbData.DB2.Extensions;
using ag.DbData.DB2.Factories;

***************************************************************************************************

// register services with extension method

		// ...
		services.AddAgDB2();
		// or
		services.AddAgDB2(config.GetSection("DB2DbDataSettings"));
		// or
		services.AddAgDB2(opts =>
        {
            opts.AllowExceptionLogging = false; // optional
			opts.ConnectionString = YOUR_CONNECTION_STRING; // optional
        });

***************************************************************************************************

// inject IDB2DbDataFactory into your classes

        private readonly IDB2DbDataFactory _db2Factory;

        public MyClass(IDB2DbDataFactory db2Factory)
        {
            _db2Factory = db2Factory;
        }

***************************************************************************************************

// DB2DbDataObject implements IDisposable interface, so use it into 'using' directive

        using (var db2DbData = _db2Factory.Create(YOUR_CONNECTION_STRING))
        {
            using (var t = db2DbData.FillDataTable("SELECT * FROM YOUR_TABLE"))
            {
                foreach (DataRow r in t.Rows)
                {
                    Console.WriteLine(r[0]);
                }
            }
        }

// in case you have defined connection string in configuration setting you may call Create() method
// without parameter

        using (var db2DbData = _db2Factory.Create())
        {
            using (var t = db2DbData.FillDataTable("SELECT * FROM YOUR_TABLE"))
            {
                foreach (DataRow r in t.Rows)
                {
                    Console.WriteLine(r[0]);
                }
            }
        }

***************************************************************************************************