using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.LocalDatabase.Entities
{
    public class VersionEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Version { get; set; }
        public DateTime ChangedOn { get; set; }
    }
}
