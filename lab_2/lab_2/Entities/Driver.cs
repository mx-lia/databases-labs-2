using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Entities
{
    [Table(Name = "drivers")]
    class Driver
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Driver_ID { get; set; }
        [Column(Name = "vehicle_id")]
        public Vehicle Vehicle { get; set; }
        [Column]
        public string Surname { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Patronymic { get; set; }
    }
}
