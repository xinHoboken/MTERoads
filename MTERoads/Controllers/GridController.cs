using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MTERoads.Models;
using MTERoads.ViewModels;

namespace MTERoads.Views
{
    public class GridController : Controller
    {
        private RoadsEntities db = new RoadsEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest]DataSourceRequest request)
        {

            return Json(GetTransactions().ToDataSourceResult(request));
        }

        private static IEnumerable<TranViewModel> GetTransactions()
        {
            RoadsEntities dbCtx = new RoadsEntities();
            return dbCtx.tblTransactions.Select(tran => new TranViewModel
            {
                AutoNumber = tran.AutoNumber,
                Emp_Name = tran.tblEmp.Emp_Name,
                Mach_Desc = tran.tblMach.Mach_Desc,
                Road_Name = tran.tblRoad.Road_Name,
                Activity_Desc = tran.tblAct.Activity_Desc,
                Hours = tran.Hours,
                Lease_Rate = tran.Lease_Chg
            });
        }

        public ActionResult tblMaches_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<tblMach> tblmaches = db.tblMaches;
            DataSourceResult result = tblmaches.ToDataSourceResult(request, tblMach => new
            {
                Mach_No = tblMach.Mach_No,
                Mach_Desc = tblMach.Mach_Desc,
                Lease_Rate = tblMach.Lease_Rate,
                Active = tblMach.Active,
            });

            return Json(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
