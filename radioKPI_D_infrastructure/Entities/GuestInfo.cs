using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class GuestInfo
    {
        public int Id { get; set; }
        //public User Guest { get; set; }
        public string PlacesOfWorkOrStudy { get; set; }
        public string JobTitlesOrSpecializations { get; set; }
        public ICollection<Subjects> Subjects { get; set; }
        public string? Notes { get; set; }
    }
}
