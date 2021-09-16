using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Games2.Models;
using Games2.Repositorio;

namespace Games2.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Funcionario()
        {
            var funcionario = new Funcionario();
            return View(funcionario);
        }

        AcoesFunc acFunc = new AcoesFunc();

        [HttpPost]

        public ActionResult CadFuncionario(Funcionario func)
        {
            acFunc.CadastrarFuncionario(func);
            return View(func);

        }

        public ActionResult ListarFuncionario()
        {
            var ExibirFunc = new AcoesFunc();
            var TodosFunc = ExibirFunc.ListarFuncionario();
            return View(TodosFunc);

        }
    }
}