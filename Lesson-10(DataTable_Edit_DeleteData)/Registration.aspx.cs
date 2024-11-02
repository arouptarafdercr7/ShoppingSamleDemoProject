using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson_10_DataTable_Edit_DeleteData_
{
    public partial class Registration : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            tblUser reg = new tblUser();

            reg.uName = txtUserName.Text;
            reg.uEmail = txtEmail.Text;
            reg.uPassword = txtPassword.Text;
            reg.rId = 2; //ekhane rId 1 dile Admin er jonno hobe.jehetu rId 2,tar mane General er jonno

            db.tblUsers.Add(reg);
            db.SaveChanges();

            Literal1.Text = "Insert Register Successfully...";

            Response.Redirect("LogIn.aspx");
        }
    }
}