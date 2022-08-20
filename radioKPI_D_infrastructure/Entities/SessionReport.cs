using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class SessionReport
    {
        public int Id { get; set; }
        public string ReportText { get; set; }
        public ICollection<PartialReport> PartialReports { get; set; }
    }
}
