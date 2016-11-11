using CarFuel.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarFuel.Web.Services {
    public class UserService :IUserService{

        public string CurrentUserId() {
            return HttpContext.Current.User.Identity.GetUserId();
        }

        public bool IsLoggedIn() {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}