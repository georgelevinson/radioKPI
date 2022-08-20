using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_infrastructure.DbModels
{
    public class Session
    {
        public int Id { get; set; }
        public Proposal Proposal { get; set; }
        public Sufflere Sufflere { get; set; }
        public DateTime RecordingDate { get; set; }
        //public ApplicationUser RecEngineer { get; set; }
        //public ApplicationUser Videograph { get; set; }
    }
}
