using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CusCar.Controllers
{
    public class ComplainController : Controller
    {
        //
        // GET: /Complain/
        public ActionResult Index()
        {
            if(Session["UserId"]==null)
            {
                Response.Redirect("/Login/Index");
            }

            return View();
        }

        public ActionResult Detail()
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("/Login/Index");
            }
            return View();   
        }
	}
}