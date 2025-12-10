using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.Domain.Entities
{
    public class Order : BaseEntity
    {
       
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
