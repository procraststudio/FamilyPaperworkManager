using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyPaperworkManager
{

    // TO DO: Automatic numbering system for documents
    public class IDSystem
    {
        private Dictionary<int, int> documentCounts = new Dictionary<int, int>();

        public string GenerateDocumentNumber(int year)
        {
            if (!documentCounts.ContainsKey(year))
            {
                documentCounts[year] = 1;
            }
            else
            {
                documentCounts[year]++;
            }

            string documentNumber = documentCounts[year].ToString("D2");

            return $"{documentNumber}/{year % 100:D2}";
        }
    }
}
