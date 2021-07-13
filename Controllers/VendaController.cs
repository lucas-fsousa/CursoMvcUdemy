using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoMvcUdemy.Models;
using Microsoft.AspNetCore.Http;

namespace CursoMvcUdemy.Controllers {
  public class VendaController : Controller {

    // Recebe informação do usuario logado via injeção de dependência.
    private IHttpContextAccessor HttpUserLog;
    public VendaController(IHttpContextAccessor HttpContextAccessor) {
      HttpUserLog = HttpContextAccessor;
    }

    public IActionResult Index() {
      ViewBag.ListaVendas = VendaModel.ListaVendasDetalhadas();
      return View();
    }

    [HttpGet]
    public IActionResult Registrar() {
      ViewBagsItens();
      return View();
    }

    public void ViewBagsItens() {
      ViewBag.Clientes = VendaModel.RetornaClientes();
      ViewBag.Produtos = VendaModel.RetornaProdutos();
      string[] vendedor_state = { HttpUserLog.HttpContext.Session.GetString("IdAutenticado"), HttpUserLog.HttpContext.Session.GetString("LoginAutenticado") };
      ViewBag.Vendedor = vendedor_state;
    }

    [HttpPost]
    public IActionResult Registrar(VendaModel venda) {
      if(ModelState.IsValid) {
        venda.Inserir();
      }
      ViewBagsItens();
      return View();
    }
  }
}
