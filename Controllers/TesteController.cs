using MvcTeste.Filters;
using MvcTeste.Models;
using MvcTeste.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcTeste.Controllers
{

    [RoutePrefix("teste")]
    [Route("{action=Dados}")]
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            var cursos = RetornaCursos();
            var model = new AlunoViewModel
            {
                Nome = "",
                Senha = "",
                IsAtivo = false,
                IdCurso = 0,
                DataCadastro = DateTime.Now,
                CursoOptions = new SelectList(cursos, "Id", "NomeCurso")
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            return View();
        }

        public int numero()
        {
            return 1;
        }
        private List<Curso> RetornaCursos()
        {
            return new List<Curso>()
            {
                new Curso() {Id = 1, NomeCurso = "Matematica", CargaHoraria = 10},
                new Curso() {Id = 2, NomeCurso = "Portugues", CargaHoraria = 10},
                new Curso() {Id = 3, NomeCurso = "Informatica", CargaHoraria = 8},
                new Curso() {Id = 4, NomeCurso = "Primeiros socorros", CargaHoraria = 4},
            };
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
        [LogActionFiltercs()]
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
        [Route("minharota/{id:int}")]
        public string action1(int id)
        {
            return "OK! CHEGUEI NA ROTA!";
        }

        [Route("~/rotaignorada/{id:int}")]
        public string action2(int id)
        {
            return "OK! CHEGUEI NA ROTA!";
        }
        [Route("rota/{categoria:maxlength(3)}")]
        public string action2(string categoria)
        {
            return "OK! CHEGUEI NA ROTA!" + categoria;
        }
        [Route("rota2/{categoria:minlength(3)}")]
        public string action3(string categoria)
        {
            return "OK! CHEGUEI NA ROTA!" + categoria;
        }
    }
}