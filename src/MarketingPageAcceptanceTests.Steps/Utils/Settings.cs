using Microsoft.Extensions.Configuration;

namespace MarketingPageAcceptanceTests.Steps.Utils
{
    public class Settings
    {
        public string HubUrl { get; set; }

        public string SupplierMarketingPageUrl { get; set; }
        public string AuthorityMarketingPageUrl { get; set; }

        public string Browser { get; set; }

        public DatabaseSettings DatabaseSettings { get; set; }

        // workaround for not including UITest everywhere
        public bool CreateNewSolution { get; set; }


        public Settings(IConfiguration config)
        {
            HubUrl = config.GetValue<string>("hubUrl");            
            SupplierMarketingPageUrl = config.GetValue<string>("mpSupplierUrl");
            AuthorityMarketingPageUrl = config.GetValue<string>("mpAuthorityUrl");
            Browser = config.GetValue<string>("browser");
            DatabaseSettings = SetUpDatabaseSettings(config);
        }

        private DatabaseSettings SetUpDatabaseSettings(IConfiguration config)
        {
            var databaseSettings = config.GetSection("db").Get<DatabaseSettings>();
            databaseSettings.ConnectionString = ConstructDatabaseConnectionString(
                databaseSettings.ServerUrl,
                databaseSettings.DatabaseName,
                databaseSettings.User,
                databaseSettings.Password);
            return databaseSettings;
        }

        private static string ConstructDatabaseConnectionString(string serverUrl, string databaseName, string user, string password) =>
            string.Format(ConnectionStringTemplate, serverUrl, databaseName, user, password);

        private static string ConnectionStringTemplate => @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";
    }
}
