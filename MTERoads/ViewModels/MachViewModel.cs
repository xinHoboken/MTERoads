using MTERoads.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTERoads.ViewModels
{
    public class MachViewModel
    {
        //Machine
        [Required]
        public int? Mach_No { get; set; }
        public string Mach_Desc { get; set; }
        public Nullable<double> Lease_Rate { get; set; }
        public Nullable<int> Owner_Num { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Owner_Name { get; set; }


        public IEnumerable<tblMach> Machs { get; set; }
        public IEnumerable<tblOwner> Owners { get; set; }
    }
}