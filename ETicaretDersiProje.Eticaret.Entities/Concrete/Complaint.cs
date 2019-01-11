using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Eticaret.Entities.Concrete
{
    public class Complaint:IEntity
    {
        public int ComplaintID { get; set; }
        public string Title { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
