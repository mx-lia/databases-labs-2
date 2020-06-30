using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Entities
{
    [Table(Name = "vehicles")]
    class Vehicle
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Vehicle_ID { get; set; }
        [Column]
        public string Model { get; set; }
        [Column]
        public string Number { get; set; }
    }
}
