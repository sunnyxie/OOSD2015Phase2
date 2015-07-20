/*
 * Author: Geetha, Linden, Sunny
 * Date: July 05, 2015
 * Description: Model for Package table data
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Package
{
    public Package() { }
    public int PackageId { get; set; }
    public string PkgName { get; set; }
    public DateTime PkgStartDate { get; set; }
    public DateTime PkgEndDate { get; set; }
    public string PkgDesc { get; set; }
    public decimal PkgBasePrice { get; set; }
    public decimal PkgAgencyCommission { get; set; }
    public override string ToString()
    {
 	    return "Package #" + PackageId + ":\n\t" + PkgName + "\n\t" + PkgStartDate + "\n\t" + PkgEndDate + "\n\t" + PkgDesc + "\n\t" + PkgBasePrice + "\n\t" + PkgAgencyCommission;
    }
    //public List<Product> productName;
}
