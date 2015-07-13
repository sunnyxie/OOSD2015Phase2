/*
 * Author: Geetha, Linden, Sunny
 * Date: July 05, 2015
 * Description: Model for ProductSupplier table data
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelData
{
    public class ProductSupplier
    {
        public ProductSupplier() { }

        //public Product Product { get; set;}

        //public Supplier Supplier { get; set; }

        public int ProductSupplierId { get; set; }

        public int ProductId { get; set; }

        public string ProdName { get; set; }

        public int SupplierId { get; set; }

        public string SupName { get; set; }
    }
}
