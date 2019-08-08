using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaRepository repositorio;
        // GET: Pessoa
        public PessoaController()
        {
            repositorio = new PessoaRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObterTodos()
        {
            var pessoas = repositorio.ObterTodos();
            var resultado = new { data = pessoas };
            return Json(resultado,JsonRequestBehavior.AllowGet);

        }
    }
}