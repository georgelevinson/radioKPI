using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using radioKPI_domain.Enums;

namespace radioKPI_infrastructure.DbModels
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
