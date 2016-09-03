using MTERoads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTERoads.ViewModels;
using System.Data.Entity;

namespace MTERoads.Controllers
{
    public class RoadsController : Controller
    {
        // GET: Roads
        public ActionResult Index()
        {
            RoadsEntities db = new RoadsEntities();
            RoadViewModel v = new RoadViewModel();
            IEnumerable<SelectListItem> item = db.tblTypes.Select(t => new SelectListItem
            {
                Value = t.Type_Id.ToString(),
                Text = t.Type_Desc,

            });
            ViewBag.Result = item;
            ViewBag.DropdownResult = db.tblTypes.ToList();

            v.Roads = db.tblRoads.ToList();

            return View("Roads", v);
        }

        public ActionResult create(RoadViewModel tbl)
        {
            RoadsEntities db = new RoadsEntities();
            tblRoad tb = new tblRoad();
            tb.BIA_No = Convert.ToInt32(tbl.BIA_No);
            tb.Road_Name = tbl.Road_Name;
            tb.Miles = tbl.Miles;
            tb.Type_Id = tbl.Type_Id;
            db.tblRoads.Add(tb);
            db.SaveChanges();
            ModelState.Clear();
            
            return Index();
        }

        
        public ActionResult update(int BIA_No, string Road_Name, string Miles, int Type_Id)
        {
            tblRoad table = new tblRoad();
            using (var db = new RoadsEntities())
            {
                table = db.tblRoads.First(em => em.BIA_No == BIA_No);
            }
            if (table != null)
            {
                table.Road_Name = Road_Name;
                table.Type_Id = Type_Id;
                table.Miles = Convert.ToDouble(Miles);
            }
            using (var dc = new RoadsEntities())
            {
                dc.Entry(table).State = EntityState.Modified;
                dc.SaveChanges();
            }


            ModelState.Clear();

            return RedirectToAction("Index");
        }
    }
}