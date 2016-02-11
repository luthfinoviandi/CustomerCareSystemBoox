using CusCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CusCar.Controllers
{
    public class ComplainApiController : Controller
    {
        private EFContext db = new EFContext();

        public JsonResult Get()
        {
            int userId = Int32.Parse(Session["UserId"].ToString());
            string userStatus = Session["UserStatus"].ToString();


            if (userStatus == "2")
            {
                var complainList = (from complain in db.Complains
                                    join complainStatusMaster in db.ComplainStatusMasters on complain.ComplainStatusId equals complainStatusMaster.ComplainStatusId
                                    where complain.UserId == userId
                                    select new
                                    {
                                        ComplainId = complain.ComplainId,
                                        UserId = complain.UserId,
                                        ComplainSubject = complain.ComplainSubject,
                                        ComplainStatusId = complain.ComplainStatusId,
                                        ComplainStatusText = complainStatusMaster.ComplainStatusText
                                    }).ToList();

                return Json(complainList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var complainList = (from complain in db.Complains
                                    join complainStatusMaster in db.ComplainStatusMasters on complain.ComplainStatusId equals complainStatusMaster.ComplainStatusId
                                    orderby complain.ComplainStatusId ascending
                                    select new
                                    {
                                        ComplainId = complain.ComplainId,
                                        UserId = complain.UserId,
                                        ComplainSubject = complain.ComplainSubject,
                                        ComplainStatusId = complain.ComplainStatusId,
                                        ComplainStatusText = complainStatusMaster.ComplainStatusText
                                    }).ToList();

                return Json(complainList, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult GetDetail(int complainId)
        {
            int userId = Int32.Parse(Session["UserId"].ToString());

            var complainList = (from complain in db.Complains
                                join user in db.Users on complain.UserId equals user.UserId
                                join complainStatusMaster in db.ComplainStatusMasters on complain.ComplainStatusId equals complainStatusMaster.ComplainStatusId 
                                where complain.ComplainId == complainId
                                select new
                                {
                                    ComplainId = complain.ComplainId,
                                    ComplainText = complain.ComplainText,
                                    ComplainSubject = complain.ComplainSubject,
                                    ComplainStatusId = complain.ComplainStatusId,
                                    ComplainStatusText = complainStatusMaster.ComplainStatusText,
                                    UserId = user.UserId,
                                    Username = user.Username,
                                    UserStatus = user.UserStatus
                                }).ToList();

            return Json(complainList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetComplainDetailList(int complainId)
        {
            var complainDetailList = (from complainDetail in db.ComplainDetails
                                      join complain in db.Complains on complainDetail.ComplainId equals complain.ComplainId
                                      join user in db.Users on complainDetail.UserId equals user.UserId
                                      where complainDetail.ComplainId == complainId
                                      select new
                                      {
                                          ComplainID = complainDetail.ComplainId,
                                          ComplainDetailText = complainDetail.ComplainDetailText,
                                          ComplainDetailId = complainDetail.ComplainDetailId,
                                          UserId = complainDetail.UserId,
                                          Username = user.Username,
                                          UserStatus = user.UserStatus
                                      }).ToList(); 
            return Json(complainDetailList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetComplainStatusList()
        {

            var complainStatusList = (from complainStatus in db.ComplainStatusMasters
                                      select new
                                      {
                                          ComplainStatusId = complainStatus.ComplainStatusId,
                                          ComplainStatusText = complainStatus.ComplainStatusText
                                      }).ToList();

            return Json(complainStatusList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Complain data)
        {
            data.UserId = Int32.Parse(Session["UserId"].ToString());

            db.Complains.Add(data);
            db.SaveChanges();

            return null;
        }

        public JsonResult PostReply(ComplainDetail data)
        {
            data.UserId = Int32.Parse(Session["UserId"].ToString());

            db.ComplainDetails.Add(data);
            db.SaveChanges();
            return null;
        }

        public JsonResult delete(Complain complain)
        {
            Complain cmp = db.Complains.Find(complain.ComplainId);

            db.Complains.Remove(cmp);
            db.SaveChanges();

            return null;
        }

        public JsonResult ChangeComplainStatus(Complain data)
        {
            var complainRow = (from complain in db.Complains
                               where complain.ComplainId == data.ComplainId
                               select complain);

            foreach(Complain complain in complainRow)
            {
                complain.ComplainStatusId = data.ComplainStatusId;
            }

            db.SaveChanges();

            return null;
        }
    }
}