using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTracker.Data;

namespace CandidateTracker
{
    public class LayoutDatabaseAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var manager = new DBManager(Properties.Settings.Default.Constr);
            filterContext.Controller.ViewBag.NumberPending = manager.GetCounts().Pending;
            filterContext.Controller.ViewBag.NumberConfirmed = manager.GetCounts().Confirmed;
            filterContext.Controller.ViewBag.NumberRefused = manager.GetCounts().Refused;
            base.OnActionExecuted(filterContext);
        }
    }
}