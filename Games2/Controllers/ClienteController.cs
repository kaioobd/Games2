using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Games2.Models;
using Games2.Repositorio;

namespace Games2.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cliente()
        {
            var cliente = new Cliente();
            return View(cliente);
        }

        AcoesCli acCli = new AcoesCli();

        [HttpPost]

        public ActionResult CadCliente(Cliente cli)
        {
            acCli.CadastrarCliente(cli);
            return View(cli);

        }

        public ActionResult ListarCliente()
        {
            var ExibirCli = new AcoesCli();
            var TodosCli = ExibirCli.ListarCliente();
            return View(TodosCli);

        }
    }
}