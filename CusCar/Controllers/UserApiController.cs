using CusCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CusCar.Controllers
{
    public class UserApiController : Controller
    {
        private EFContext db = new EFContext();

        public JsonResult GetUserStatus()
        {
            string userStatus = Session["UserStatus"].ToString();

            return Json(new { userStatus = userStatus }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUsername()
        {
            string username = Session["Username"].ToString();

            return Json(new { username = username }, JsonRequestBehavior.AllowGet);
        }
	}
}