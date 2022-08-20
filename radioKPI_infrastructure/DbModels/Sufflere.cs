using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_infrastructure.DbModels
{
    public class Sufflere
    {
        public int Id { get; set; }
        public Proposal Proposal { get; set; }
        public string SectionA { get; set; }
        public string SectionB { get; set; }
    }
}
