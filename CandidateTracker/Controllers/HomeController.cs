using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTracker.Data;

namespace CandidateTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCandidate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCandidate(Candidate c)
        {
            DBManager db = new DBManager(Properties.Settings.Default.Constr);
            db.AddCandidate(c);
            return Redirect("/home/Pending");
        }
        public ActionResult Pending()
        {
            var db = new DBManager(Properties.Settings.Default.Constr);
            return View( db.GetPendingCandidates());
        }
        public ActionResult Confirmed()
        {
            var db = new DBManager(Properties.Settings.Default.Constr);
            return View(db.GetConfirmedCandidates());
        }
        public ActionResult Refused()
        {
            var db = new DBManager(Properties.Settings.Default.Constr);
            return View(db.GetRefusedCandidates());
        }
        public ActionResult ViewDetails(int id)
        {
            DBManager db = new DBManager(Properties.Settings.Default.Constr);
            return View(db.GetCandidateById(id));
        }
        [HttpPost]
        public void ConfirmPerson(int id)
        {
            DBManager db = new DBManager(Properties.Settings.Default.Constr);
            db.Confirm(id);
        }
        [HttpPost]
        public void RefusePerson(int id)
        {
            DBManager db = new DBManager(Properties.Settings.Default.Constr);
            db.Refuse(id);
        }
        public ActionResult GetCounts()
        {
            DBManager db = new DBManager(Properties.Settings.Default.Constr);
            var counts = db.GetCounts();
            return Json(counts,JsonRequestBehavior.AllowGet);
        }
    }
}