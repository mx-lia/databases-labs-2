using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Entities
{
    [Table(Name = "products")]
    class Product
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Product_ID { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public int Weight { get; set; }
    }
}
