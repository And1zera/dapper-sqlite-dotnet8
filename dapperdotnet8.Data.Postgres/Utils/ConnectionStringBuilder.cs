namespace dapperdotnet8.Application.Utils
{
    public static class ConnectionStringBuilder
    {
        public static string BuildFromEnvironment()
        {
            string connectionString = "Data Source=MyDatabase.db";

            return connectionString;
        }
    }
}
