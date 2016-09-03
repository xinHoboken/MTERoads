using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTERoads.Models.EntityManager
{
    public class UserManager
    {
        public string GetUserPassword(string loginName)
        {
            using (RoadsEntities db = new RoadsEntities())
            {
                var user = db.tblLogins.Where(o => o.UserID.Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().Password;
                else
                    return string.Empty;
            }
        }
    }
}