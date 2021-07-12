using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoMvcUdemy.Models;

namespace CursoMvcUdemy.Controllers {
  public class ClienteController : Controller {
    public IActionResult Index() {
      ViewBag.ListaClientes = ClienteModel.ListarTodos();
      return View();
    }

    [HttpGet]
    public IActionResult Cadastrar() {
      return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(ClienteModel cliente) {
      if(ModelState.IsValid) {
        cliente.InsertEdit();
        return RedirectToAction("Index", "Cliente");
      }
      return View();
    }

    [HttpGet]
    public IActionResult Editar(int id) {
      ViewBag.Cliente = ClienteModel.ListaCliente(id);
      return View();
    }

    [HttpPost]
    public IActionResult Editar(ClienteModel cliente) {
      if(ModelState.IsValid) {
        cliente.InsertEdit();
        return RedirectToAction("Index", "Cliente");
      }
      return View();
    }

    [HttpGet]
    public IActionResult ConfirmarDel(int? id) {
      ViewBag.IdCliente = id;
      return View();
    }

    [HttpGet]
    public void Deletar(int id) {
      ClienteModel.Deletar(id);
      Response.Redirect("/Cliente/Index");
    }

  }
}
