using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class PartialReport
    {
        public int Id { get; set; }
        //public ApplicationUser Submitter { get; set; }
        public Session Session { get; set; }
        public string ReportText { get; set; }
    }
}
