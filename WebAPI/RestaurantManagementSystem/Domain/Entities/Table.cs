using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class Table
    {
        public int ReferenceNumber { get; set; }

        public int NumberOfSeats { get; set; }

        public int Index { get; set; }

        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
