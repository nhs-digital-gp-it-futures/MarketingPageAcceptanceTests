namespace MarketingPageAcceptanceTests.Steps.Utils
{
    using Microsoft.Extensions.Configuration;

    public class Settings
    {
        public Settings(IConfiguration config)
        {
            HubUrl = config.GetValue<string>("hubUrl");
            SupplierMarketingPageUrl = config.GetValue<string>("mpSupplierUrl");
            AuthorityMarketingPageUrl = config.GetValue<string>("mpAuthorityUrl");
            Browser = config.GetValue<string>("browser");
            DatabaseSettings = SetUpDatabaseSettings(config);
        }

        public string HubUrl { get; }

        public string SupplierMarketingPageUrl { get; }

        public string AuthorityMarketingPageUrl { get; }

        public string Browser { get; }

        public DatabaseSettings DatabaseSettings { get; }

        // workaround for not including UITest everywhere
        public bool CreateNewSolution { get; set; }

        private static string ConnectionStringTemplate => @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";

        private static DatabaseSettings SetUpDatabaseSettings(IConfiguration config)
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
    }
}
