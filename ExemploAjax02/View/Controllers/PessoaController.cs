using Model;
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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObterTodos()
        {
            var pessoas = repositorio.ObterTodos();
            var resultado = new { data = pessoas };
            return Json(resultado,JsonRequestBehavior.AllowGet);

        }

        //Definir que esse metodo só executa atraves de um post
        [HttpPost]
        public JsonResult Inserir(Pessoa pessoa)
        {
            pessoa.ResgitroAtivo = true;
            var id = repositorio.Inserir(pessoa);
            var resultado = new { id = id };
            return Json(resultado);
        }
    }
}