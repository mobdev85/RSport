using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.LocalDatabase.Entities
{
    public class FavoriteMusicEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public String Key { get; set; }
        public String Name { get; set; }
    }
}
