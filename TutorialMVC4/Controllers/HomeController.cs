using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorialMVC4.Models;
namespace TutorialMVC4.Controllers
{
    public class HomeController : Controller
    {
        const string SqlConnectionString = @"Data Source=DEV-PG\SQLEXPRESS;initial catalog=Tutorial;integrated security=true;";
        // GET: Home
        public ActionResult Index()
        {
            List<Product> ls = new List<Product>();
            ls.Add(new Product { ID = 1, Name = "สินค้าตัวที่ 1", Desc = "Des1", Price = 1000 ,Url= "https://store.storeimages.cdn-apple.com/4981/as-images.apple.com/is/image/AppleInc/aos/published/images/m/bp/mbp13/space/mbp13-space-select-201807?wid=452&hei=420&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1529520054457" });
            ls.Add(new Product { ID = 2, Name = "สินค้าตัวที่ 2", Desc = "Des2", Price = 2000, Url = "https://store.storeimages.cdn-apple.com/4981/as-images.apple.com/is/image/AppleInc/aos/published/images/m/bp/mbp13/space/mbp13-space-select-201807?wid=452&hei=420&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1529520054457" });
            ls.Add(new Product { ID = 3, Name = "สินค้าตัวที่ 3", Desc = "Des3", Price = 3000, Url = "https://store.storeimages.cdn-apple.com/4981/as-images.apple.com/is/image/AppleInc/aos/published/images/m/bp/mbp13/space/mbp13-space-select-201807?wid=452&hei=420&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1529520054457" });
            ls.Add(new Product { ID = 4, Name = "สินค้าตัวที่ 4", Desc = "Des4", Price = 4000, Url = "https://store.storeimages.cdn-apple.com/4981/as-images.apple.com/is/image/AppleInc/aos/published/images/m/bp/mbp13/space/mbp13-space-select-201807?wid=452&hei=420&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1529520054457" });
            return View(ls.ToList());
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddInfo(InfoModel Entity)
        {
            using(SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Customer (name,city) values(@name,@city)";
                    cmd.Parameters.AddWithValue("@name", "1");
                    cmd.Parameters.AddWithValue("@city", "2");
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            return Json("Success");

        }
    }
}