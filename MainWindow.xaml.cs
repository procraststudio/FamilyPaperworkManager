using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FamilyPaperworkManager
{

    public partial class MainWindow : Window
    {
        public Database database { get; set; }
        public static IDSystem idSystem = new IDSystem();
        public List<Contract> contracts = new List<Contract>();
        public List<Invoice> invoices = new List<Invoice>();
        public List<Document> allDocuments = new List<Document>();
        public string docsImagesPath;
        public bool deleteMode = false;
        public ApplicationModes mode;

        public enum ApplicationModes
        {
            Contracts,
            Invoices,
            Insurances,
            DutyDocs
        }

        public MainWindow()
        {
            InitializeComponent();
            database = new Database(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DemoDocumentsDB.db"));

            docsImagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "docs_images");
            if (!Directory.Exists(docsImagesPath))
            {
                Directory.CreateDirectory(docsImagesPath);
            };
        }


        private void NewDocument_Click(object sender, RoutedEventArgs e)
        {
            NewDocumentWindow newDocumentWindow = new NewDocumentWindow();
            newDocumentWindow.ShowDialog();
        }

        public void GetDocuments(string documentTypes)
        {
            //if (documentTypes.ToString() == "All documents")
            //{
            //    documentTypes == "Contracts, Insurance, Invoices";
            //}
            //else { TypeOfDocs = documentTypes; }

            using (SQLiteConnection connection = database.OpenConnection())
            {
                if (documentTypes.ToString() == "Duty_docs")
                {
                    string sql = $"SELECT * FROM Invoices WHERE DutyDate IS NOT ''";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection))
                    {
                        System.Data.DataTable dataTable = new System.Data.DataTable();
                        adapter.Fill(dataTable);
                        Document_GridView.ItemsSource = dataTable.DefaultView;
                    }
                }

                else
                {
                    string sql = $"SELECT * FROM {documentTypes}";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection))
                    {
                        System.Data.DataTable dataTable = new System.Data.DataTable();
                        adapter.Fill(dataTable);
                        Document_GridView.ItemsSource = dataTable.DefaultView;

                    }
                }
                connection.Close();
            }

        }


        private void Contracts_button_Click(object sender, RoutedEventArgs e)
        {
            mode = ApplicationModes.Contracts;
            GetDocuments("Contracts");
            Document_GridView.IsReadOnly = true;
        }

        private void Invoices_button_Click(object sender, RoutedEventArgs e)
        {
            mode = ApplicationModes.Invoices;
            GetDocuments("Invoices");
            Document_GridView.IsReadOnly = true;
        }

        private void Insurance_button_Click(object sender, RoutedEventArgs e)
        {
            mode = ApplicationModes.Insurances;
            GetDocuments("Insurance");
            Document_GridView.IsReadOnly = true;
        }

        private void Duty_docs_Button_Click(object sender, RoutedEventArgs e)
        {
            mode = ApplicationModes.DutyDocs;
            GetDocuments("Duty_docs");
            Document_GridView.IsReadOnly = true;
        }


        private void Document_GridView_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string tableName = "";
            switch (mode)
            {
                case ApplicationModes.Contracts: { tableName = "Contracts"; } break;
                case ApplicationModes.Invoices: { tableName = "Invoices"; } break;
                case ApplicationModes.Insurances: { tableName = "Insurance"; } break;
                default: { tableName = "Invoices"; } break;
            }
            string columnName = "";

            string rowId = "";


            var selectedRecord = e.Row.Item;
            string newValue = ((TextBox)e.EditingElement).Text;
            columnName = e.Column.Header.ToString();
            string id = ((DataRowView)e.Row.Item).Row.Field<string>("ID");
  
            Debug.WriteLine("NEW VALUE: " + newValue);
            Debug.WriteLine("COLUMN NAME: " + columnName);


            using (SQLiteConnection connection = database.OpenConnection())
            {
                if ((deleteMode) && (selectedRecord != null))
                {
                    MessageBoxResult result = MessageBox.Show($"DELETE DOCUMENT {((DataRowView)e.Row.Item).Row.Field<string>("Title")}?",
                        "DELETING DOCUMENT", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        string sql = $"DELETE FROM {tableName} WHERE ID = '{id}'";

                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("DOCUMENT DELETED");
                        deleteMode = false;

                    }
                }
                else
                {
                    string sql = $"UPDATE {tableName} SET {columnName} = '{newValue}' WHERE ID = '{id}'";

                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("DOCUMENT UPDATED");
                }

                connection.Close();
            }
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            Document_GridView.IsReadOnly = false;
        }


        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {

            deleteMode = true;
            Document_GridView.IsReadOnly = false;

        }


    }
}


