using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_infrastructure.DbModels
{
    public class ProdProcess
    {
        public int Id { get; set; }
        public GuestInfo GuestInfo { get; set; }
        public Proposal Proposal { get; set; }
        public Sufflere Sufflere { get; set; }
        public Session Session { get; set; }
        public SessionReport SessionReport { get; set; }
    }
}
