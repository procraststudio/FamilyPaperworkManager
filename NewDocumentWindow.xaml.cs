using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using static FamilyPaperworkManager.MainWindow;

namespace FamilyPaperworkManager
{
    /// <summary>
    /// Interaction logic for NewDocumentWimdow.xaml
    /// </summary>
    public partial class NewDocumentWindow : Window
    {
        public DateTime CreationDate { get; set; }
        public DateTime selectedDate;

        public string docImageName = "";
        public bool inEditDocumentMode = false;
        MainWindow mainWindow = new MainWindow();
        //public DateTime DutyDate { get; set; }

        public NewDocumentWindow()
        {
            InitializeComponent();
            AddCurrentDate();
            
            //FillListBox();
        }


        private void AddCurrentDate()
        {
            DateTime date = DateTime.Now;
            CurrentDate.Text = date.ToString();
        }



        private void AddNewDocument()
        {
            // IDSystem idSystem = new IDSystem();
            //idSystem = MainWindow.idSystem;
            //document.ID = idSystem.GenerateDocumentNumber(DateTime.Now.Year);
            //byte[] image = GetDocumentImage(this.docImageName);
            string documentType = DocumentType_ListBox.SelectedItem.ToString();

           
            //string table = "";
            //string tableName = "";
            //switch (documentType)
            //{
            //    case "Contract": { tableName = "Contracts"; } break;
            //    case "Invoice": { tableName = "Invoices"; } break;
            //    case "Insurance": { tableName = "Insurance"; } break;
            //}
            // Document document = new Document(idSystem, DocumentName_text.Text, DateTime.Now, null, Notes_text.Text);
            if ((DocumentName_text.Text != "") && (DocumentType_ListBox.SelectedItem != null) && (DocumentID_text.Text != ""))
            {
                if (documentType == "Contract")
                {
                    Contract contract = new Contract(DocumentID_text.Text, DocumentName_text.Text, DateTime.Now, Notes_text.Text, selectedDate);
                    using (SQLiteConnection connection = mainWindow.database.OpenConnection())
                    {
                        using (SQLiteCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Contracts (ID, Title, Date, Description, EndOfContractDate) " +
                                  "VALUES (@ID, @Title, @Date, @Description, @EndOfContractDate)";
                            command.Parameters.AddWithValue("@ID", contract.ID);
                            command.Parameters.AddWithValue("@Title", contract.Title);
                            command.Parameters.AddWithValue("@Date", contract.Date);
                            command.Parameters.AddWithValue("@Description", contract.Description);
                            command.Parameters.AddWithValue("@EndOfContractDate", contract.EndOfContractDate);
                            command.ExecuteNonQuery();
                        }

                        mainWindow.database.CloseConnection(connection);
                        
                    }
                }
                else if (documentType == "Invoice")
                {
                    Invoice invoice = new Invoice (DocumentID_text.Text, DocumentName_text.Text, DateTime.Now, Notes_text.Text, decimal.Parse(MoneyToPay_text.Text), selectedDate);
                    using (SQLiteConnection connection = mainWindow.database.OpenConnection())
                    {
                        using (SQLiteCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Invoices (ID, Title, Date, Description, moneyToPay, DutyDate) " +
                                  "VALUES (@ID, @Title, @Date, @Description, @moneyToPay, @DutyDate)";
                            command.Parameters.AddWithValue("@ID", invoice.ID);
                            command.Parameters.AddWithValue("@Title", invoice.Title);
                            command.Parameters.AddWithValue("@Date", invoice.Date);
                            command.Parameters.AddWithValue("@Description", invoice.Description);
                            command.Parameters.AddWithValue("@moneyToPay", invoice.moneyToPay);
                            command.Parameters.AddWithValue("@DutyDate", invoice.DutyDate);
                            command.ExecuteNonQuery();
                        }
                        mainWindow.database.CloseConnection(connection);
                       
                    }
                }
                else if (documentType == "Insurance")
                {
                    Insurance insurance = new Insurance (DocumentID_text.Text, DocumentName_text.Text, DateTime.Now, Notes_text.Text, selectedDate);
                    using (SQLiteConnection connection = mainWindow.database.OpenConnection())
                    {
                        using (SQLiteCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Insurance (ID, Title, Date, Description, EndOfInsuranceDate) " +
                                  "VALUES (@ID, @Title, @Date, @Description, @EndOfInsuranceDate)";
                            command.Parameters.AddWithValue("@ID", insurance.ID);
                            command.Parameters.AddWithValue("@Title", insurance.Title);
                            command.Parameters.AddWithValue("@Date", insurance.Date);
                            command.Parameters.AddWithValue("@Description", insurance.Description);
                            command.Parameters.AddWithValue("@EndOfInsuranceDate", insurance.EndOfInsuranceDate);
                            command.ExecuteNonQuery();
                        }
                        mainWindow.database.CloseConnection(connection);

                    }
                }

                MessageBox.Show("Document saved");
                Close();
            }
            else
                {
                    MessageBox.Show("NAME / DOCUMENT TYPE / ID NOT SELECTED");
                    return;
                }
        }


        private void calendarCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            DutyDateCalendar.Visibility = Visibility.Visible;

        }

        private void calendarCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            DutyDateCalendar.Visibility = Visibility.Hidden;
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DutyDateCalendar.SelectedDate.HasValue)
            {
                selectedDate = DutyDateCalendar.SelectedDate.Value;
                DutyDate_text.Text = selectedDate.ToShortDateString();
                DutyDate_checkbox.IsChecked = false;
            }
        }

        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Load only graphic files (*.jpg, *.png)|*.jpg;*.png";


            if (openFileDialog.ShowDialog() == true)
            {
                string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "docs_images");
                string selectedFilePath = openFileDialog.FileName;
                string documentName = DocumentName_text.Text;
                docImageName = documentName;

                // Copy file to docs_images "docs_images" (with System.IO.File).
                if (!string.IsNullOrEmpty(documentName) && System.IO.File.Exists(selectedFilePath))
                {
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }

                    string destinationPath = System.IO.Path.Combine(folderPath, documentName+".jpg");
                    //System.IO.Path.GetExtension(selectedFilePath));
                    System.IO.File.Copy(selectedFilePath, destinationPath, true);
                 MessageBox.Show("Image file uploaded");

                }
               
            }
        }

        private byte[] GetDocumentImage(object img)
        {
            MemoryStream stream = new MemoryStream();
            // imageBox.Image.Save(stream, imageBox.Image.RawFormat);
            return stream.GetBuffer();
        }


        private void FillListBox(object sender, RoutedEventArgs e)
        {
            DocumentType_ListBox.ItemsSource = Enum.GetValues(typeof(TypesOfDocuments.TypesOfDocs));
        }

        private void AddDocument_button_Click(object sender, RoutedEventArgs e)
        {
           AddNewDocument();    
        }

   

        private void DocumentType_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string documentType = DocumentType_ListBox.SelectedItem.ToString();
            if ((documentType == "Contract") || (documentType == "Insurance"))
            {
                MoneyToPay_text.Visibility = Visibility.Hidden;
                MoneyToPay_label.Visibility = Visibility.Hidden;
            }
            else
            {
                MoneyToPay_text.Visibility = Visibility.Visible;
                MoneyToPay_label.Visibility = Visibility.Visible;
            }
        }
    }


}

