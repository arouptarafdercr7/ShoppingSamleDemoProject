using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson_10_DataTable_Edit_DeleteData_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnInsert.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            //GridView te Refresh er jonno
            //Nicher code na diye run korle Output GridView dekhabe na

            GridView1.DataSource = db.Customers.ToList();
            GridView1.DataBind();

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
                txtEmail.Text = gvr.Cells[5].Text;
                txtAddress.Text = gvr.Cells[6].Text;
                txtPhone.Text = gvr.Cells[7].Text;

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
                txtEmail.Text = gvr.Cells[5].Text;
                txtAddress.Text = gvr.Cells[6].Text;
                txtPhone.Text = gvr.Cells[7].Text;

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
                txtEmail.Text = gvr.Cells[5].Text;
                txtAddress.Text = gvr.Cells[6].Text;
                txtPhone.Text = gvr.Cells[7].Text;

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
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#exampleModal').modal('show');"); //ekhane show means Modal close na kora porjonto show thakbe
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();

            cus.Name = txtName.Text;
            cus.Email = txtEmail.Text;
            cus.Address = txtAddress.Text;
            cus.Phone = txtPhone.Text;
            if (FileUpload1.HasFile)
            {
                cus.Photo = FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath("./Pic/") + FileUpload1.FileName);
            }


            db.Customers.Add(cus);
            db.SaveChanges();

            //GridView refresh 
            GridView1.DataSource = db.Customers.ToList();
            GridView1.DataBind();

            Literal1.Text = "Successfully Inserted !!!";

            //modal add korar jonno nicher code dite hobe
            //sb.Append("$('#exampleModal').modal('show');");
            //exampleModal,show or hide just ei 3ta change hobe
            //exampleModal eikhane jei id dibo source sei id dite hobe

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Record Added Successfully');");   //eita Optioanl.dileo hobe,na dileo hobe
            sb.Append("$('#exampleModal').modal('hide');"); //ekhane hide means Modal hide hoye jabe
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(txtId.Text);
            var data = db.Customers.Where(d => d.Id == x).FirstOrDefault();

            if (data != null)
            {
                data.Name = txtName.Text;
                data.Email = txtEmail.Text;
                data.Address = txtAddress.Text;
                data.Phone = txtPhone.Text;

                if (FileUpload1.HasFile)
                {
                    data.Photo = FileUpload1.FileName;
                    FileUpload1.SaveAs(MapPath("./Pic/") + FileUpload1.FileName);
                }

                //Update er jonno only db.SaveChanges();

                db.SaveChanges();

                GridView1.DataSource = db.Customers.ToList();
                GridView1.DataBind();

                Literal1.Text = "Successfully Updated !!!";

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Record Added Successfully');");   //Optioanl.dileo hobe,na dileo hobe
                sb.Append("$('#exampleModal').modal('hide');"); //ekhane hide means Modal hide hoye jabe
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);

            }
            else
            {
                txtName.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";

                Literal1.Text = "Sorry ! Not Updated !!!";
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(txtId.Text);
            var data = db.Customers.Where(d => d.Id == x).FirstOrDefault();

            if (data != null)
            {
                db.Customers.Remove(data);
                db.SaveChanges();

                txtName.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";

                GridView1.DataSource = db.Customers.ToList();
                GridView1.DataBind();

                Literal1.Text = "Successfully Deleted !!!";

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Record Added Successfully');");   //Optioanl.dileo hobe,na dileo hobe
                sb.Append("$('#exampleModal').modal('hide');"); //ekhane hide means Modal hide hoye jabe
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);

            }
            else
            {
                txtName.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";

                Literal1.Text = "Sorry !Can Not Deleted !!!";
            }

        }
    }

}