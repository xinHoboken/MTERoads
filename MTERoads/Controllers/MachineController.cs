using MTERoads.Models;
using MTERoads.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MTERoads.Controllers
{
    public class MachineController : Controller
    {
        private RoadsEntities db;

        public ActionResult Index()
        {
            RoadsEntities dbCxt = new RoadsEntities();
            MachViewModel mvm = new MachViewModel();
            mvm.Machs = dbCxt.tblMaches.ToList();
            mvm.Owners = dbCxt.tblOwners.ToList();
            IEnumerable<SelectListItem> item = dbCxt.tblOwners.Select(t => new SelectListItem
            {
                Value = t.Owner_Num.ToString(),
                Text = t.Owner_Name,
            });
            ViewBag.mResult = item;
            ViewBag.DropdownResult = new SelectList(dbCxt.tblOwners, "Owner_Num", "Owner_Name");

            return View("Machine", mvm);
        }

        public ActionResult AddMachine(tblMach mac)
        {
            RoadsEntities dbCxt = new RoadsEntities();
            //if (dbCxt.tblMaches.Select(m => m.Mach_No == mac.Mach_No) != null)
            //{
            //    ModelState.AddModelError("", "Cannot add duplicate Machine Code.");
            //}
            //else
            //{
                using (RoadsEntities db = new RoadsEntities())
                {
                    db.tblMaches.Add(mac);
                    db.SaveChanges();
                    ModelState.Clear();
                }
            //}
            return RedirectToAction("Index");
        }

        public ActionResult Update(int Mach_No, string Mach_Desc, double Lease_Rate, int Owner_Num, bool Active)
        {
            tblMach tblmach;
            using (db = new RoadsEntities())
            {
                tblmach = db.tblMaches.First(m => m.Mach_No == Mach_No);
            }
            if (tblmach != null)
            {
                tblmach.Mach_Desc = Mach_Desc;
                tblmach.Lease_Rate = Lease_Rate;
                tblmach.Owner_Num = Owner_Num;
                tblmach.Active = Active;
            }
            using (var dbCtx = new RoadsEntities())
            {
                dbCtx.Entry(tblmach).State = System.Data.Entity.EntityState.Modified;
                dbCtx.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Index");
        }

    }
}