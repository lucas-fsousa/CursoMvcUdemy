using CursoMvcUdemy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMvcUdemy.Controllers {
  public class RelatorioController : Controller {
    public IActionResult Index() {
      return View();
    }

    [HttpGet]
    public IActionResult Venda() {
      return View();
    }

    [HttpPost]
    public IActionResult Venda(RelatorioModel venda) {
      ViewBag.ListaVendas = venda.FiltroListaVendasDetalhadas();
      return View();
    }

    public IActionResult Grafico() {
      return View();
    }


    public IActionResult Comissao() {
      return View();
    }
  }
}
