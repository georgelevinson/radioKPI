using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class Episode
    {
        public int Id { get; set; }
        public ICollection<ProdProcess> ProductionProcesses { get; set; }
        //public ICollection<PostProdProcess> PostProductionProcesses { get; set; }
        //public Status Status { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseNotes { get; set; }
    }
}
