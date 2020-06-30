using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Entities
{
    [Table(Name = "orders")]
    class Order
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Order_ID { get; set; }
        [Column(Name = "client_id")]
        public Client Client { get; set; }
        [Column(Name = "product_id")]
        public Product Product { get; set; }
        [Column(Name = "driver_id")]
        public Driver Driver { get; set; }
        [Column(Name = "manager_id")]
        public Manager Manager { get; set; }
        [Column]
        public DateTime Order_date { get; set; }
        [Column]
        public DateTime Delivery_date { get; set; }
        [Column]
        public string Mark_of_delivery { get; set; }
    }
}
