using FamilyPaperworkManager;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FamilyPaperworkManager
{
    public class Document : IImageProvider
    {
        private string title = "";
        [Column("Title")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string date;
        [Column("Date")]
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string id;
        [Column("ID")]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        
        private string description;
        [Column("Description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string ImagePath { get; set; }

        public Document(string _id, string documentName, DateTime dateOfCreation, string descriptionText) 
        {
            int year = dateOfCreation.Year;
            ID = _id;
            //ID = idSystem.GenerateDocumentNumber(year);
            Title = documentName;
            Date = dateOfCreation.ToString("yyyy-MM-dd");
            Description = descriptionText;  
        }

        public byte[] GetImage()
        {
            ImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "docs_images");
            if (File.Exists(ImagePath))
            {
                return File.ReadAllBytes(ImagePath);
            }
            else
            {  
               Debug.WriteLine("NO IMAGE");
               return null;
            }
           
        }
    }

    
    public class Contract : Document, IImageProvider
    {
        [Column("EndOfContractDate")]
        public string EndOfContractDate { get; private set; }

        public Contract(string _id, string title, DateTime date, string descriptionText, DateTime endDate) : base(_id, title, date, descriptionText)
        {
            EndOfContractDate = endDate.ToString("yyyy-MM-dd");
        }


    }
    public class Invoice : Document, IImageProvider
    {
        public decimal moneyToPay { get; set; }
        private string dutyDate;
        public string DutyDate
        {
            get { return dutyDate; }
            set { dutyDate = value; }
        }

        public Invoice(string _id, string title, DateTime date, string descriptionText, decimal amount, DateTime dateOfDuty) : base(_id, title, date, descriptionText)
        {
            moneyToPay = amount;
            DutyDate = dateOfDuty.ToString("yyyy-MM-dd");
        }


    }

    public class Insurance: Document, IImageProvider
    {
        [Column("EndOfInsuranceDate")]
        public string EndOfInsuranceDate { get; private set; }

        public Insurance(string _id, string title, DateTime date, string descriptionText, DateTime endDate) : base(_id, title, date, descriptionText)
        {
            EndOfInsuranceDate = endDate.ToString("yyyy-MM-dd");
        }


    }
}

