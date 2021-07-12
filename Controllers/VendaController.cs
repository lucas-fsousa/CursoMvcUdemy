using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoMvcUdemy.Models;

namespace CursoMvcUdemy.Controllers {
  public class VendaController : Controller {

    public IActionResult Index() {
      //ViewBag.ListaVendas = VendaModel.ListaVendas();
      ViewBag.TesteDic = VendaModel.listardict();
      return View();
    }

    [HttpGet]
    public IActionResult Registrar() {
      ViewBagsItens();
      return View();
    }

    public void ViewBagsItens() {
      ViewBag.Clientes = VendaModel.RetornaClientes();
      ViewBag.Vendedores = VendaModel.RetornaVendedores();
      ViewBag.Produtos = VendaModel.RetornaProdutos();
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
