using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderItem.Models
{
    public class Cart
    {
        public int Id { get; set; }
        
        public int userId { get; set; }

        public int menuItemId { get; set; }

        public string menuItemName { get; set; }
    }
}
