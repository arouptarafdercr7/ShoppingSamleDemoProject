using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson_10_DataTable_Edit_DeleteData_
{
    public partial class DeleteData : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Deleteid"] != null) // return "<a href='EditData.aspx?Editid=" + idn + "' >Edit</a>"
                {
                    int x = Int32.Parse(Request.QueryString["Deleteid"].ToString());
                    var data = db.Products.Where(d => d.Id == x).FirstOrDefault();
                    if (data != null)
                    {
                        txtProductName.Text = data.ProductName;
                        txtQuantity.Text = data.Quantity.ToString();
                        txtPrice.Text = data.Price.ToString();
                        Image1.ImageUrl = "./Pic/" + data.ProductImage;
                    }

                }
                else
                {
                    Response.Redirect("DataTableExample.aspx");
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //kono product order hoye gele seita r Delete hobe na

            int x = Int32.Parse(Request.QueryString["Deleteid"].ToString());
            var data = db.Products.Where(d => d.Id == x).FirstOrDefault();

            if (data != null)
            {
                try
                {
                    db.Products.Remove(data);
                    db.SaveChanges();
                    Response.Redirect("DataTableExample.aspx");
                }
                catch (Exception)
                {
                    Literal1.Text = "Sorry! Can not deleted.....";
                }
            }
        }

    }
}