// using System;
// using System.Collections.Generic;
// using MySqlConnector;
// using System.Threading.Tasks;
// class Program
// {
//     static async Task Main(string[] args)
//     {
//         string connectionString = "Server=b738iwjjktqxwu1dlp1p-mysql.services.clever-cloud.com;User ID=uckw5o6komfx5m4u;Password=54k62OBhiR1XVCJGZFZl;Database=b738iwjjktqxwu1dlp1p";
//         var connection = new MySqlConnection(connectionString);
//         // connection.Open();
//         Console.WriteLine("connection success!");
//         await connection.OpenAsync();

//         using var command = new MySqlCommand("SELECT * FROM Category;", connection);
//         using var reader = await command.ExecuteReaderAsync();
//         Console.WriteLine("reader success!", reader);

//         // while (await reader.ReadAsync())
//         // {
//         //     var columnValue = reader.GetString(0); // Adjust the index based on your query
//         //     Console.WriteLine(columnValue);
//         // }
//     }
// }
