using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class Restaurant
    {
        private const int _areaWidth = 15;
        private const int _areaHeight = 10;

        public Restaurant()
        {
            Id = Guid.NewGuid();
            AreaWidth = _areaWidth;
            AreaHeight = _areaHeight;
            Tables = new List<Table>();
        }
        public Guid Id {get;set;}

        public string Name { get; set; }

        public bool IsInitialized()
        {
            return !string.IsNullOrEmpty(Name);
        }
        public string ManagerEmail { get; set; }

        public User Manager { get; set; }

        public int AreaWidth { get; set; }

        public int AreaHeight { get; set; }

        public List<Table> Tables { get; set; }

    }
}
