using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.LocalDatabase.Entities;
using URSpot.Core.Models.User;

namespace URSpot.Core.Api.Mappings
{
    public static class DbEntityToModel
    {
        public static UserModel ToModel(this UserEntity data)
        {
            return new UserModel();
        }
    }
}
