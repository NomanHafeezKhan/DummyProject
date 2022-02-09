using Dapper;
using System;
using WebApplication1.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace WebApplication1.Controllers
{
    //[RequireHttps]

    public class testclass
    {
        public int userId { get; set; }
        public string password { get; set; }
    }
    public class ProcResp
    {
        public int StatusCode  { get; set; }
        public string Msg { get; set; }
    }
    public class HomeController : Controller
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBstring"].ToString());
        
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult particle()
        {
            
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Addcategory(int ID=0) // Work while we request page  
        {
            var result = await con.QueryAsync<ModelContext>("select * from tbl_Dummy where _id='" + ID + "'");
            ModelContext bj = result?.FirstOrDefault();
            //IEnumerable<ModelContext> obj = await Listcategory1();
            return View(bj ?? new ModelContext());
            //if (ID != 0) { 
            //var result= await con.QueryAsync<ModelContext>("select * from tbl_Dummy where _id='" + ID + "'");
            //ModelContext bj = result.FirstOrDefault();
            ////IEnumerable<ModelContext> obj = await Listcategory1();
            //return View(bj);
            //}
            //else
            //{
            //    return View(new ModelContext());

            //}

        }
        [HttpPost]
        public ActionResult Addcategory(ModelContext model) // Work while we post page  
        {
            if (model.Id<0)
            { 
            string query = " insert into tbl_Dummy (_Name,_Age,_City) values(@Name,@Age,@City)";
            con.Execute(query, new { model.Name, model.Age,model.City });
                return RedirectToAction("Listcategory");
            }
            else
            {
                string query = " update tbl_Dummy set _Name=@Name,_Age=@Age,_City=@City where _id='" + model.Id + "'";
                con.Execute(query, new { model.Name, model.Age, model.City });
                return RedirectToAction("Listcategory");

            }

        }
        public async Task<ActionResult> Listcategory()
        {
            IEnumerable<ModelContext> bj = await con.QueryAsync<ModelContext>("select * from tbl_Dummy");
            //IEnumerable<ModelContext> obj = await Listcategory1();
            return View(bj);
        }
        public async Task<IEnumerable<ModelContext>> Listcategory1()
        {
            
            IEnumerable<ModelContext> bj = await con.QueryAsync<ModelContext>("select * from tbl_Dummy");
            return bj;
        }
        [HttpGet]
        public ActionResult Delete(int ID) // Work while we request page  
        {
            string query = "delete from tbl_Dummy where _id='" + ID + "'";
            con.Execute(query, new { ID });
            ViewBag.Message = String.Format("Delete");
            return RedirectToAction("Listcategory");
        }
        [HttpPost]
        public ActionResult Edit(int ID)
        {
             return RedirectToAction("Addcategory");
        }

        public ActionResult marksAction()
        {
            marks_sem_sub obj = new marks_sem_sub();
        
            return View(obj);
        }
    }
}