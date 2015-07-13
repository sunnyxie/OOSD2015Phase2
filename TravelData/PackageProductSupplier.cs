/*
 * Author: Geetha
 * Date: July 06, 2015
 * Usage: Entity class for PackageProductSupplier
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelData
{
    public class PackageProductSupplier
    {
        public PackageProductSupplier() { }

        //public variables for package
        public int PackageId { get; set; }

        public string PkgName { get; set; }

        public string PkgDes { get; set; }

        public DateTime PkgStartDate { get; set; }

        public DateTime PkgEndDate { get; set; }

        public decimal PkgBasePrice { get; set; }

        public decimal PkgAgencyCommission { get; set; }

        public int ProductSupplierId { get; set; }

        public int ProductId { get; set; }

        public string ProdName { get; set; }

        public int SupplierId { get; set; }

        public string SupName { get; set; }
    }
}
