using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoMvcUdemy.Models;

namespace CursoMvcUdemy.Controllers {
  public class VendedorController : Controller {
    public IActionResult Index() {
      ViewBag.ListaVendedores = VendedorModel.ListarTodos();
      return View();
    }

    [HttpGet]
    public IActionResult Cadastrar() {
      return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(VendedorModel vendedor) {
      if(ModelState.IsValid) {
        vendedor.InsertEdit();
        return RedirectToAction("Index", "Vendedor");
      }
      return View();
    }

    [HttpGet]
    public IActionResult Editar(int id) {
      ViewBag.Vendedor = VendedorModel.ListaVendedor(id);
      return View();
    }

    [HttpPost]
    public IActionResult Editar(VendedorModel vendedor) {
      if(ModelState.IsValid) {
        vendedor.InsertEdit();
        return RedirectToAction("Index", "Vendedor");
      }
      return View();
    }

    [HttpGet]
    public IActionResult ConfirmarDel(int? id) {
      ViewBag.IdVendedor = id;
      return View();
    }

    [HttpGet]
    public void Deletar(int id) {
      VendedorModel.Deletar(id);
      Response.Redirect("/Vendedor/Index");
    }



  }
}
