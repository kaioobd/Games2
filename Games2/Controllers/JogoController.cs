using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Games2.Models;
using Games2.Repositorio;

namespace Games2.Controllers
{
    public class JogoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Jogo()
        {
            var jogo = new Jogo();
            return View(jogo);
        }

        AcoesJogo acJogo = new AcoesJogo();

        [HttpPost]

        public ActionResult CadJogo(Jogo jogo)
        {
            acJogo.CadastrarJogo(jogo);
            return View(jogo);

        }

        public ActionResult ListarJogo()
        {
            var ExibirJogo = new AcoesJogo();
            var TodosJogo = ExibirJogo.ListarJogo();
            return View(TodosJogo);

        }
    }
}