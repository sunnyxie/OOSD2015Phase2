﻿/*
 * Author: Geetha, Linden, Sunny
 * Date: July 05, 2015
 * Description: Model for Packages table data
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelData
{
    public class Packages
    {
        public Packages() { }

        public int PackageId { get; set; }

        public string PkgName { get; set; }

        public DateTime PkgStartDate { get; set; }

        public DateTime PkgEndDate { get; set; }

        public string PkgDesc { get; set; }

        public decimal PkgBasePrice { get; set; }

        public decimal PkgAgencyCommission { get; set; }

        //public List<Product> productName;

    }
}
