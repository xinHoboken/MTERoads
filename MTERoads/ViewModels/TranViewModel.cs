using MTERoads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTERoads.ViewModels
{
    public class TranViewModel
    {
        public int AutoNumber { get; set; }

        //Machine
        public Nullable<int> Mach_No { get; set; }
        public string Mach_Desc { get; set; }
        public Nullable<double> Lease_Rate { get; set; }


        //Employee
        public int Emp_no { get; set; }
        public string Emp_Name { get; set; }

        //Activity
        public Nullable<int> Activity_Code { get; set; }
        public string Activity_Desc { get; set; }


        //Road
        public Nullable<int> BIA_No { get; set; }
        public string Road_Name { get; set; }

        //Transaction
        public Nullable<double> Hours { get; set; }
        public Nullable<System.DateTime> Trans_Date { get; set; }
        public Nullable<double> Lease_Chg { get; set; }

        public IEnumerable<tblMach> Machs { get; set; }
        public IEnumerable<tblEmp> Emps { get; set; }
        public IEnumerable<tblAct> Acts { get; set; }
        public IEnumerable<tblRoad> Roads { get; set; }
        public IEnumerable<tblTransaction> Transactions { get; set; }


    }
}