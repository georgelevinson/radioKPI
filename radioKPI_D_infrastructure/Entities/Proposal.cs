using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class Proposal
    {
        public int Id { get; set; }
        public GuestInfo Guest { get; set; }
        public string Description { get; set; }
        public string OrgNotes { get; set; }
    }
}
