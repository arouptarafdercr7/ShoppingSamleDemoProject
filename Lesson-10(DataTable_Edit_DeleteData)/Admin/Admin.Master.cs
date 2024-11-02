using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson_10_DataTable_Edit_DeleteData_.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["un"] == null)
            {
                Response.Redirect("~/LogIn.aspx");
            }

        }
    }
}