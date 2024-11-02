using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson_10_DataTable_Edit_DeleteData_
{
    public partial class PrintOrder : System.Web.UI.Page
    {
        decimal total; //total is variable.eita GridView1_RowDataBound er jonno

        Database1Entities db = new Database1Entities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //d.Customer.CName means Customer Table er CName bujhai

            int inVNo = Int32.Parse(txtInvoiceNo.Text);
            var data = db.Orders.Select(d => new { d.Id, d.OrderDate, d.GrandTotal, d.Customer.Name, d.Customer.Address }).Where(a => a.Id == inVNo).FirstOrDefault();

            if (data != null)
            {
                lblInvoice.Text = data.Id.ToString();
                lblCustomer.Text = data.Name;
                lblTotal.Text = data.GrandTotal.ToString();
                lblOrderDate.Text = data.OrderDate.ToString();
                lblAddress.Text = data.Address;


                var details = db.OrderDetails.Select(p => new { p.Id, p.Product.ProductName, p.SalesPrice, p.SalesQTY, p.SaleTotal }).Where(d => d.Id == data.Id).ToList();
                GridView1.DataSource = details;
                GridView1.DataBind();

                //var details = db.OrderDetails.Where(d => d.Id == data.Id).ToList();
                //GridView1.DataSource = details;
                //GridView1.DataBind();

                //p.Product.ProductName means Product Table er ProductName bujhai
                //1st selector.properties
                //jodi onno table er properties dorkar hoi tahole  1st selector.Table Name.properties

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                total = 0;  //0 means ekhane Header value 0
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += decimal.Parse(e.Row.Cells[3].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total Amount"; //ekhane Cells[2] means 2 number Cells Total Amount likha dekhabe
                e.Row.Cells[3].Text = total.ToString(); //ekhane 3 number Cells Total Amount dekhabe
            }

        }
    }
}