using MySql.Data.MySqlClient;

namespace RfidLibraryManagement.Data
{
    public static class Database
    {
        private static readonly string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=rfid_library;" +
            "User ID=root;" +
            "Password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using MySqlConnection connection = GetConnection();

                connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
