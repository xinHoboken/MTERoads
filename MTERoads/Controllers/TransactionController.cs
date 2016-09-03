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

namespace MTERoads.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            TranViewModel tvm;
            RoadsEntities dbCxt = new RoadsEntities();
            tvm = new TranViewModel();

            tvm.Machs = dbCxt.tblMaches.ToList();
            tvm.Acts = dbCxt.tblActs.ToList();
            tvm.Emps = dbCxt.tblEmps.ToList();
            tvm.Roads = dbCxt.tblRoads.ToList();
            tvm.Transactions = dbCxt.tblTransactions.ToList();
            return View("LoadTransaction", tvm);
        }
        [HttpPost]
        public ActionResult AddTransaction(TranViewModel tvm)
        {
            using (RoadsEntities db = new RoadsEntities())
            {
                tblTransaction tt = new tblTransaction();
                tt.Trans_Date = tvm.Trans_Date;
                tt.Emp_No = tvm.Emp_no;
                tt.Mach_No = tvm.Mach_No;
                tt.BIA_No = tvm.BIA_No;
                tt.Activity_Code = tvm.Activity_Code;
                tt.Hours = tvm.Hours;
                tt.Lease_Chg = tvm.Lease_Chg;
                db.tblTransactions.Add(tt);
                db.SaveChanges();
                ModelState.Clear();
            }
            return RedirectToAction("Index");
        }

        public static IEnumerable<TranViewModel> GetTransaction()
        {
            RoadsEntities entity = new RoadsEntities();
            return entity.tblTransactions.Select(tl => new TranViewModel
            {
                AutoNumber = tl.AutoNumber,
                Emp_Name = tl.tblEmp.Emp_Name,
                Mach_Desc = tl.tblMach.Mach_Desc,
                Road_Name = tl.tblRoad.Road_Name,
                Activity_Desc = tl.tblAct.Activity_Desc,
                Trans_Date = tl.Trans_Date,
                Hours = tl.Hours,
                Lease_Chg = tl.Lease_Chg
            });
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetTransaction().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Update([DataSourceRequest] DataSourceRequest request, TranViewModel tran)
        {
            RoadsEntities db = new RoadsEntities();
            var t = db.tblTransactions.Where(tr => tr.AutoNumber.Equals(tran.AutoNumber)).FirstOrDefault();
            t.Hours = tran.Hours;
            t.Lease_Chg = tran.Lease_Chg;
            db.SaveChanges();
            return Json(new[] { tran }.ToDataSourceResult(request, ModelState));
        }       

    }
}