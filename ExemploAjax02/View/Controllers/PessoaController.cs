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

        [HttpGet]
        public JsonResult Apagar(int id)
        {
           var apagou = repositorio.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Pessoa pessoa)
        {
            var alterou = repositorio.Alterar(pessoa);
            var resultado = new { status = alterou };
            return Json(resultado);
        }

        [HttpGet,Route("pessoa/obterpeloid")]
        public JsonResult ObterPeloId(int id)
        {
            return Json(repositorio.ObterPeloId(id),JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("pessoa/obtertodosselect2")]
        public JsonResult ObterTodosSelect2(string term)
        {
            var pesssoas = repositorio.ObterTodos();
            List<object> pessoasSelect2 = new List<object>();
            foreach (Pessoa pessoa in pesssoas)
            {
                pessoasSelect2.Add(new
                {
                    id = pessoa.Id,
                    text = pessoa.Nome
                });
            }

            var resultado = new
            {
                result = pessoasSelect2
            };

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}