using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Lesson_10_DataTable_Edit_DeleteData_
{
    /// <summary>
    /// Summary description for ProductService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {

        //Import    using System.Data.SqlClient;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;");

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //Create GetProducts Method for Json format.Key type WebMethod.WebMethod means URL call kore.
        [WebMethod]
        public void GetProducts()
        {
            List<clsProduct> productList = new List<clsProduct>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())   //Must be use while condition for looping get all products
            {
                clsProduct product = new clsProduct();

                product.Id = Convert.ToInt32(dr[0].ToString());
                product.ProductName = dr[1].ToString();
                product.Quantity = Convert.ToInt32(dr[2].ToString());
                product.Price = decimal.Parse(dr[3].ToString());
                product.ProductImage = dr[4].ToString();
                product.CategoryId = Convert.ToInt32(dr[5].ToString());

                productList.Add(product);

            }
            con.Close();

            //This is Json format
            //var js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(productList));

            //or single line code

            //Import      using System.Web.Script.Serialization;

            Context.Response.Write(new JavaScriptSerializer().Serialize(productList));

        }

        //Create GetAllProducts Method for Json format or Array format or xml format or user define format.Key type WebMethod.WebMethod means URL call kore.
        [WebMethod]
        public clsProduct[] GetAllProducts()
        {
            List<clsProduct> productList = new List<clsProduct>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())   //Must be use while condition for looping get all products
            {
                clsProduct product = new clsProduct();

                product.Id = Convert.ToInt32(dr[0].ToString());  //OR   product.Id =Int32.Parse(dr[0].ToString());
                product.ProductName = dr[1].ToString();
                product.Quantity = Convert.ToInt32(dr[2].ToString()); //OR  product.Quantity = Int32.Parse(dr[2].ToString());
                product.Price = decimal.Parse(dr[3].ToString());
                product.ProductImage = dr[4].ToString();
                product.CategoryId = Convert.ToInt32(dr[5].ToString()); //OR    product.CategoryId = Int32.Parse(dr[5].ToString());

                productList.Add(product);

            }
            con.Close();
            //This is Array format or xml format or user define format.when use it.Please declare Array[] sign.look like  public clsProduct[] GetAllProducts()

            return productList.ToArray();

        }

        [WebMethod]
        public void UpdateProduct(Product prod)
        {
            Database1Entities db = new Database1Entities();

            var data = db.Products.Where(d => d.Id == prod.Id).FirstOrDefault();

            data.ProductName = prod.ProductName;
            data.Quantity = prod.Quantity;
            data.Price = prod.Price;
            data.ProductImage = prod.ProductImage;
            db.SaveChanges();
        }

        [WebMethod]
        public void DeleteProduct(string idn)
        {
            int id = Int32.Parse(idn);

            Database1Entities db = new Database1Entities();

            var data = db.Products.Where(d => d.Id == id).FirstOrDefault();

            db.Products.Remove(data);
            db.SaveChanges();
        }

    }
}
