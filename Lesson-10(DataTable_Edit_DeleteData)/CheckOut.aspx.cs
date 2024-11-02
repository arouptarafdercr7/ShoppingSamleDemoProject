using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson_10_DataTable_Edit_DeleteData_
{
    public partial class CheckOut : System.Web.UI.Page
    {
        //Import   using System.Data; For DataTable
        DataTable dt = new DataTable();
        decimal total; //total is variable.eita GridView1_RowDataBound er jonno

        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pk"] != null)    //Session means memory variable
            {
                dt = (DataTable)Session["pk"];

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                Response.Redirect("BuyProduct.aspx");   //for go to another page
            }
        }

        //GridView er event theke RowDataBound double click kore nicher code
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                total = 0;  //0 means ekhane Header value 0
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += decimal.Parse(e.Row.Cells[5].Text);
                lblCount.Text = ((DataTable)Session["pk"]).Rows.Count.ToString();
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total Amount"; //ekhane Cells[4] means 4 number Cells Total Amount likha dekhabe
                e.Row.Cells[5].Text = total.ToString(); //ekhane 5 number Cells Total Amount dekhabe

                //GridView er propertises theke ShowFooter,ShowHeaderWhenEmpty true kore dite hobe

            }
        }

        //GridView er event theke RowDeleting double click kore nicher code
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridView Design er moddhe Delete button er jonno CommandField theke Delete nite hobe
            dt.Rows.RemoveAt(e.RowIndex);   //Grid er jei row click korbo oitai RowIndex
            GridView1.DataBind();
            grandTotal();

            lblCount.Text = ((DataTable)Session["pk"]).Rows.Count.ToString();
        }
        //Crate grandTotal Method
        public decimal grandTotal()
        {
            decimal gT = 0;  // decimal gT = 0; eita just dhore neya hoyeche

            //Loop
            //GridView1.Rows means GridView1 er sob gulo Row
            //je koita Row ase sob GridViewRow r er moddhe rakhbe
            //  r means akta Row bujhai
            //je koita Row thakbe tar prothom Row r er moddhe rakhbe
            //then 2nd Row,3rd Row ................

            foreach (GridViewRow r in GridView1.Rows)
            {
                gT += decimal.Parse(r.Cells[4].Text);
                //decimal.Parse(r.Cells[4].Text); means GridView er Row(1st,2nd,3rd.....je koita Row thakbe) er 4 number Cells/Column er Text decimal convert kore gT er moddhe rakhbe
                //je koita Row totobar ee erokomvabe Loop hobe
            }
            return gT; //gT return korbe
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuyProduct.aspx"); //for go to another page
        }

        protected void btnEndShopping_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();

            cus.Name = txtCustomerName.Text;
            cus.Email = txtEmail.Text;
            cus.Address = txtAddress.Text;
            cus.Phone = txtPhoneNumber.Text;
            if (FileUpload1.HasFile)
            {
                cus.Photo = FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath("./Pic/") + FileUpload1.FileName);
            }

            if (txtEnroll.Text != "")
            {
                cus.DOE = DateTime.Parse(txtEnroll.Text);
            }

            db.Customers.Add(cus);
            db.SaveChanges();


            Order o = new Order();
            o.OrderDate = DateTime.Now;
            o.GrandTotal = grandTotal();

            db.Orders.Add(o);
            db.SaveChanges();

            foreach (GridViewRow r in GridView1.Rows)
            {
                OrderDetail oD = new OrderDetail();

                oD.Id = o.Id;
                oD.PId = Int32.Parse(r.Cells[1].Text);
                oD.SalesQTY = Int32.Parse(r.Cells[3].Text);
                oD.SalesPrice = decimal.Parse(r.Cells[4].Text);

                // oD.SaleTotal = decimal.Parse(r.Cells[5].Text);

                db.OrderDetails.Add(oD);
                db.SaveChanges();

            }
            dt.Clear();   //for DataTable clear
            GridView1.DataBind();

            Literal1.Text = "Order Placed";

            SendMail();
        }

        //jodi kono code k method er moddhe nite chai tahole code select kore right mouse Quick Actions and Refactorings click,then Extract Method click,NewMethod name er poriborte method er name,then Apply click
        //create SendMail Method
        private void SendMail()         //DataType void means true/false check kora
        {
            // Display Name: Admin
            // Password: cdsd spxt nuyw uxul     // Create App Password from gmail

            // Create the email message
            //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            //OR

            // Import   using System.Net.Mail;
            MailMessage mail = new MailMessage();

            // Add recipient email address
            mail.To.Add(txtEmail.Text);

            // Set sender email address and display name
            mail.From = new MailAddress("apnionekcute@gmail.com", "Admin", System.Text.Encoding.UTF8);

            // Set email subject
            mail.Subject = "Thank You For Purchase !!!";


            ////body can edit or design
            //string body = "";
            //body += "</br>";
            //body += "</br>";
            //body += "</br>";
            //body += "</br>";
            //body += "</br>";
            //body += "</br>";
            //body += "</br>";
            //body += "Best Regards";
            //body += "Manager, AAAA";

            ////mail.Body = "Hello,";
            //mail.Body = body;
            //mail.IsBodyHtml = true;

            //OR 

            // Construct email body (HTML format)
            string body = "<br/><br/><br/><br/><br/><br/><br/>Best Regards<br/>Manager, AAAA";
            mail.Body = body;
            mail.IsBodyHtml = true;  // Marking email body as HTML


            // Configure SMTP client
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("apnionekcute@gmail.com", "cdsd spxt nuyw uxul");  // Replace with secure storage in production
            client.Port = 587;  // Port for TLS/STARTTLS
            client.Host = "smtp.gmail.com";  // Gmail SMTP server
            client.EnableSsl = true;  // Enable SSL for security

            // Try sending the email
            try
            {
                client.Send(mail);  // Send the email
                                    // If you're in a web context (ASP.NET), use ClientScript or ScriptManager for a success alert
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent');", true);
            }
            catch (Exception ex)
            {
                // Handle the exception and show the error message
                // In a web context, you might show this in a literal or log it instead
                Literal1.Text = $"Error sending email: {ex.Message}";
            }

        }

    }
}