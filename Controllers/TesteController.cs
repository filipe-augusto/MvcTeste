using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcTeste.Controllers
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    } 

    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index()
        {
            return View();
        }

        public int numero()
        {
            return 1;
        }

        public ViewResult Dados()
        {
            var aluno = new Aluno
            {
                Id = 1,
                Nome = "filipe"
            };
            ViewBag.Categoria = "Categoria viewBag";
            ViewData["Categoria"] = "Categoria Viewdata";
            TempData["Categoria"] = "Categoria Tempdata";
            Session["Categoria"] = "Categoria Session";
            return View(aluno);
        }

        public JsonResult json()
        {

            return Json(new { Id = 1, Nome = "Filipe" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult json1(int id, string nome)
        {

            return Json(new { Id = id, Nome = nome }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult obj()
        {
            var autor = new Aluno() { Id = 1, Nome = "Filipe" };
            return  Json(autor, JsonRequestBehavior.AllowGet);
        }

        public JsonResult obj1(int id, string nome)
        {
            var autor = new Aluno() { Id = id, Nome = nome };
            return Json(autor, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult obj2(Aluno aluno)
        {
            
            return Json(aluno, JsonRequestBehavior.AllowGet);
        }
    }
}