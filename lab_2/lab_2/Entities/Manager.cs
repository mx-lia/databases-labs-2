using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Entities
{
    [Table(Name = "managers")]
    class Manager
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Manager_ID { get; set; }
        [Column]
        public string Surname { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Patronymic { get; set; }
        [Column]
        public string Phone { get; set; }
    }
}
