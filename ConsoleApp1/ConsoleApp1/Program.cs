using System.Data.SqlClient;

string userInput = "aaaa";

// 脆弱性：SQLインジェクション
string query = "SELECT * FROM Users WHERE username = '" + userInput + "'";

using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=MyDb;Integrated Security=True"))
{
    SqlCommand command = new SqlCommand(query, connection);
    connection.Open();
    SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"ユーザーID: {reader["id"]}, 名前: {reader["username"]}");
    }
}