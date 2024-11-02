using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson_10_DataTable_Edit_DeleteData_
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = db.Categories.ToList();

                DropDownList1.DataSource = data;
                DropDownList1.DataTextField = "CategoryName";
                DropDownList1.DataValueField = "CategoryId";
                DropDownList1.DataBind();

                //GridView te Refresh er jonno
                //Nicher code na diye run korle Output GridView dekhabe na

                GridView1.DataSource = db.Products.ToList();
                GridView1.DataBind();
            }

        }


        //GridView er Event theke RowCommand double click kore
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Database kono Data Na thakle GridView er Properties theke ShowHeaderWhenEmpty true kore dile output header dekhabe

            int x = Convert.ToInt32(e.CommandArgument); //CommandArgument means Row Number

            //CommandName jeita,ekhane double cotation er vitore tai dite hobe
            //GridView er View,Update,Delete button show korar jonno UpdatePanel er vitore nite hobe.source er vitore nicher step 

            //< asp:UpdatePanel ID = "UpdatePanel2" runat = "server" >

            //       < ContentTemplate >

            //       .................ekhane statement.It means table,button

            //       </ ContentTemplate >

            //   </ asp:UpdatePanel >

            if (e.CommandName == "V")
            {
                btnInsert.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                //need comment
                //TextBox value dekhanor jonno nicher code

                string code = GridView1.DataKeys[x].Value.ToString();

                GridViewRow gvr = GridView1.Rows[x];
                txtId.Text = gvr.Cells[3].Text;
                txtName.Text = gvr.Cells[4].Text;
                txtQuantity.Text = gvr.Cells[5].Text;
                txtPrice.Text = gvr.Cells[6].Text;

                //Modal er moddhe Image show er jonno
                int rx = Int32.Parse(txtId.Text);
                var data = db.Products.Where(d => d.Id == rx).FirstOrDefault();
                Image1.ImageUrl = "./Pic/" + data.ProductImage;

                DropDownList1.Text = gvr.Cells[8].Text;

                //modal add korar jonno nicher code dite hobe
                //sb.Append("$('#exampleModal').modal('show');");
                //exampleModal,show or hide just ei 3ta change hobe
                //exampleModal eikhane jei id dibo source sei id dite hobe

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#exampleModal').modal('show');");//exampleModal eita Source er Modal er ID
                sb.Append(@"</script>");                       //ekhane show means Modal close na kora porjonto show thakbe
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);


                Literal1.Text = code.ToString();//For show primary key
                                                //Literal1.Text = code.ToString();

            }
            else if (e.CommandName == "U")
            {
                btnInsert.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = false;

                string code = GridView1.DataKeys[x].Value.ToString();

                GridViewRow gvr = GridView1.Rows[x];
                txtId.Text = gvr.Cells[3].Text;
                txtName.Text = gvr.Cells[4].Text;
                txtQuantity.Text = gvr.Cells[5].Text;
                txtPrice.Text = gvr.Cells[6].Text;

                //Image show er jonno
                int rx = Int32.Parse(txtId.Text);
                var data = db.Products.Where(d => d.Id == rx).FirstOrDefault();
                Image1.ImageUrl = "./Pic/" + data.ProductImage;

                DropDownList1.Text = gvr.Cells[8].Text;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#exampleModal').modal('show');");//exampleModal eita Source er Modal er ID
                sb.Append(@"</script>");                       //ekhane show means Modal close na kora porjonto show thakbe
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);


                Literal1.Text = code.ToString();//For show primary key
                                                //Literal1.Text = code.ToString();

            }
            else if (e.CommandName == "D")
            {
                btnInsert.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = true;

                string code = GridView1.DataKeys[x].Value.ToString();

                GridViewRow gvr = GridView1.Rows[x];
                txtId.Text = gvr.Cells[3].Text;
                txtName.Text = gvr.Cells[4].Text;
                txtQuantity.Text = gvr.Cells[5].Text;
                txtPrice.Text = gvr.Cells[6].Text;

                //Image show er jonno
                int rx = Int32.Parse(txtId.Text);
                var data = db.Products.Where(d => d.Id == rx).FirstOrDefault();
                Image1.ImageUrl = "./Pic/" + data.ProductImage;

                DropDownList1.Text = gvr.Cells[8].Text;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#exampleModal').modal('show');");//exampleModal eita Source er Modal er ID
                sb.Append(@"</script>");                       //ekhane show means Modal close na kora porjonto show thakbe
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);


                Literal1.Text = code.ToString();//For show primary key
                                                //Literal1.Text = code.ToString();

            }

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnInsert.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            Image1.ImageUrl = null;                //for Image Blank
            DropDownList1.SelectedValue = "0";  //For DropDownList Blank

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#exampleModal').modal('show');"); //ekhane show means Modal close na kora porjonto show thakbe
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Product pro = new Product();

            pro.ProductName = txtName.Text;
            pro.Quantity = Int32.Parse(txtQuantity.Text);
            pro.Price = decimal.Parse(txtPrice.Text);
            pro.CategoryId = Int32.Parse(DropDownList1.SelectedValue.ToString());
            if (FileUpload1.HasFile)
            {
                pro.ProductImage = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath("./Pic/") + FileUpload1.FileName);

            }


            db.Products.Add(pro);
            db.SaveChanges();

            //GridView refresh 
            GridView1.DataSource = db.Products.ToList();
            GridView1.DataBind();

            Literal1.Text = "Successfully Inserted !!!";

            //modal add korar jonno nicher code dite hobe
            //sb.Append("$('#exampleModal').modal('show');");
            //exampleModal,show or hide just ei 3ta change hobe
            //exampleModal eikhane jei id dibo source sei id dite hobe

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Record Inserted Successfully');");   //Optioanl.dileo hobe,na dileo hobe
            sb.Append("$('#exampleModal').modal('hide');"); //ekhane hide means Modal hide hoye jabe
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(txtId.Text);
            var data = db.Products.Where(d => d.Id == x).FirstOrDefault();

            if (data != null)
            {
                data.ProductName = txtName.Text;
                data.Quantity = Int32.Parse(txtQuantity.Text);
                data.Price = decimal.Parse(txtPrice.Text);
                data.CategoryId = Int32.Parse(DropDownList1.SelectedValue.ToString());
                if (FileUpload1.HasFile)
                {
                    data.ProductImage = FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath("./Pic/") + FileUpload1.FileName);

                }

                //Update er jonno only db.SaveChanges();

                db.SaveChanges();

                GridView1.DataSource = db.Products.ToList();
                GridView1.DataBind();

                Literal1.Text = "Successfully Updated !!!";

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Record Updated Successfully');");   //Optioanl.dileo hobe,na dileo hobe
                sb.Append("$('#exampleModal').modal('hide');"); //ekhane hide means Modal hide hoye jabe
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);

            }
            else
            {
                Literal1.Text = "Can Not Updated !!!";
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(txtId.Text);
            var del = db.Products.Where(d => d.Id == x).FirstOrDefault();

            if (del != null)
            {
                db.Products.Remove(del);
                db.SaveChanges();

                GridView1.DataSource = db.Products.ToList();
                GridView1.DataBind();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Record Deleted Successfully');");   //Optioanl.dileo hobe,na dileo hobe
                sb.Append("$('#exampleModal').modal('hide');"); //ekhane hide means Modal hide hoye jabe
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);


                Literal1.Text = "Successfully Deleted !!!";
            }
            else
            {
                Literal1.Text = "Sorry Can Not Deleted !!!";
            }

        }

    }
}