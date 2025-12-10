using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.Application.DTOClasses
{
    public class OrderDetailDto : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

    }
}
