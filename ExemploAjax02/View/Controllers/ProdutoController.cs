using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoRepository repository;

        public ProdutoController()
        {
            repository = new ProdutoRepository();
        }

        [HttpGet, Route("obtertodospeloidvenda")]
        public JsonResult ObterPeloIdVenda(int idVenda)
        {
            var produto = repository.ObterProdutosPeloIdVenda(idVenda);
            var result = new { data = produto };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            //na parte do javascript temos o ajax success, só entra la se o retorno for 200,
            //retornando not found ele é 400 e vai pra erro
            var produto = repository.ObterPeloId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost, Route("cadastro")]
        public ActionResult Cadastro(Produto produto)
        {
            var id = repository.Inserir(produto);
            var result = new { id = id };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost, Route("alterar")]
        public ActionResult Alterar(Produto produto)

        {
            var alterou = repository.Alterar(produto);
            var resultado = new { status = alterou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        [HttpGet,Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


    }
}