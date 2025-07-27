using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.OrderDtos
{
    public class UpdatedOrderStatusDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
