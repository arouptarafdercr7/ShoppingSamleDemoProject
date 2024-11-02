using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson_10_DataTable_Edit_DeleteData_
{
    public partial class EditData : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Editid"] != null) // return "<a href='EditData.aspx?Editid=" + idn + "' >Edit</a>"
                {
                    int x = Int32.Parse(Request.QueryString["Editid"].ToString());
                    var data = db.Products.Where(d => d.Id == x).FirstOrDefault();
                    if (data != null)
                    {
                        txtProductName.Text = data.ProductName;
                        txtQuantity.Text = data.Quantity.ToString();
                        txtPrice.Text = data.Price.ToString();       //database theke textbox rakhle ToString() kore rakhte hobe.textbox theke database rakhle parse kore rakhte hobe
                        Image1.ImageUrl = "./Pic/" + data.ProductImage;
                    }

                }
                else
                {
                    Response.Redirect("DataTableExample.aspx");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(Request.QueryString["Editid"].ToString());
            var data = db.Products.Where(d => d.Id == x).FirstOrDefault();

            if (data != null)
            {
                data.ProductName = txtProductName.Text;
                data.Quantity = Int32.Parse(txtQuantity.Text);
                data.Price = decimal.Parse(txtPrice.Text);
                //data.CategoryId = Int32.Parse(DropDownList1.SelectedValue.ToString());
                if (FileUpload1.HasFile)
                {
                    data.ProductImage = FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath("./Pic/") + FileUpload1.FileName);

                }

                db.SaveChanges();
                Response.Redirect("DataTableExample.aspx");
            }
        }

    }
}