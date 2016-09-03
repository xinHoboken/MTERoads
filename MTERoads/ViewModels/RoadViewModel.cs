using MTERoads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTERoads.ViewModels
{
    public class RoadViewModel
    {
        public int? BIA_No { get; set; }
        public string Road_Name { get; set; }
        public int SelectedID { set; get; }
        public Nullable<int> Type_Id { get; set; }
        public Nullable<double> Miles { get; set; }
        public string Type_Desc { get; set; }


        public IEnumerable<tblRoad> Roads { get; set; }
        public virtual IEnumerable<tblType> Types { get; set; }
    }
}