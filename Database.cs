using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;

namespace FamilyPaperworkManager
{
    public class Database
    {
        private string connectionString;
       // MainWindow mainWindow = new MainWindow();
        public Database database { get; set; }
       

        public Database(string dbFilePath)
        {
           connectionString = $"Data Source={dbFilePath};Version=3;";

        }

        public SQLiteConnection OpenConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            return connection;
        }

        public void CloseConnection(SQLiteConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public static void SaveDocument(Document document)
        {
            Debug.WriteLine("TRYING TO SAVE");

        }

    }
}
