using Microsoft.Data.SqlClient;

namespace WebApi.Models
{
    public class Appeal : IAppeal
    {
        public Appeal() { }
        public Appeal(int Id, string Name, string Email, string UserAppeal)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email; 
            this.userAppeal = UserAppeal;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string userAppeal { get; set; }

        static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Appeals;Trusted_Connection=True;";
        
        static List<IAppeal> appeals = new List<IAppeal>();
        public IEnumerable<IAppeal> GetAppeal()
        {
            appeals.Clear();
            NullAppeal();
                return appeals;
        }
        static IEnumerable<IAppeal> NullAppeal()
        {
            string sqlExpression = "SELECT * FROM Appeals";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);
                    string columnName3 = reader.GetName(2);
                    string columnName4 = reader.GetName(3);

                    while (reader.Read()) // построчно считываем данные
                    {
                        int id = reader.GetFieldValue<int>(0);
                        string name = reader.GetFieldValue<string>(1);
                        string email = reader.GetFieldValue<string>(2);
                        string appeal = reader.GetFieldValue<string>(3);
                        appeals.Add(new Appeal(id, name, email, appeal));
                    }
                }

                reader.CloseAsync();
            }
            return appeals;
        }
        static void ToSql(IAppeal appeal)
        {
            string sqlExpression = $"INSERT INTO Appeals (Name,Email,userAppeal) VALUES (N'{appeal.Name}',N'{appeal.Email}',N'{appeal.userAppeal}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }
        public void AddAppeal(IAppeal appeal)
        {
            appeal.Id = appeals.Count+1;
            ToSql(appeal);
        }
    }
}
