using CusCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CusCar.Controllers
{
    public class LoginApiController : Controller
    {
        private EFContext db = new EFContext();

        public JsonResult Login(User data)
        {
            var userRecord = (from user in db.Users
                              where user.Username == data.Username &&
                              user.Password == data.Password
                              select new
                              {
                                  UserId = user.UserId,
                                  Username = user.Username,
                                  UserStatus = user.UserStatus
                              }).ToList();

            int userCount = userRecord.Count();

            if (userCount > 0)
            {
                Session["Username"] = data.Username;
                Session["UserId"] = userRecord[0].UserId;
                Session["UserStatus"] = userRecord[0].UserStatus;
               
                return Json(new { IsLogin = true });
            }
            else
            {
                return Json(new { IsLogin = false, ErrorMessage = "Username or Password not match" });
            }
             
        }
    }
}