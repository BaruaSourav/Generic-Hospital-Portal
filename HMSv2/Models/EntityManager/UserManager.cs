using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSv2.Models.DB;

namespace HMSv2.Models.EntityManager
{
    public class UserManager
    {
        HMS_DBEntities db = new HMS_DBEntities();

        public string GetUserPW(string un)
        {
            var user = db.User.Where(o => o.Username.ToLower().Equals(un));
            if (user.Any())
            {
                return user.FirstOrDefault().Password;
            }
            else return string.Empty;
        }

        public string GetUserRole(string un)
        {
            var user = db.User.Where(o => o.Username.ToLower().Equals(un));
            if (user.Any())
            {
                return user.FirstOrDefault().Role;
            }
            else return string.Empty;
        }

        
        public bool isLoggedIn()
        {
            bool isLoggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            return isLoggedIn;
        }

        public void checkAdmin() {
        }
    }
}