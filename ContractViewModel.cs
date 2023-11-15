using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyPaperworkManager
{
    public class ContractViewModel
    {
        //This class added for exercises with SQLite
        public string ID { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }

        
        public string Description { get; set; }

        public string EndOfContractDate { get; set; }

        //IDSystem idSystem, string documentName, DateTime dateOfCreation, byte[] imageData
    }
}
