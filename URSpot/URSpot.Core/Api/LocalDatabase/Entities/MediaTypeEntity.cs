using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.LocalDatabase.Entities
{
    public class MediaTypeEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public String Key { get; set; }
        public String Name { get; set; }
        public String NameAr { get; set; }
    }
}
