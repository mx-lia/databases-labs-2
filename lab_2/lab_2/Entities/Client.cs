using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Entities
{
    [Table(Name = "clients")]
    class Client
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Client_ID { get; set; }
        [Column]
        public string Surname { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Patronymic { get; set; }
        [Column]
        public string Phone { get; set; }
        [Column]
        public string Address { get; set; }
        [Column]
        public string Passport { get; set; }
        [Column]
        public string Payment_account { get; set; }
    }
}
