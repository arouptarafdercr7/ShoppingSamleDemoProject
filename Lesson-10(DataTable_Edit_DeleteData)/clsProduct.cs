using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson_10_DataTable_Edit_DeleteData_
{
    public class clsProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ProductImage { get; set; }
        public Nullable<int> CategoryId { get; set; }
    }
}