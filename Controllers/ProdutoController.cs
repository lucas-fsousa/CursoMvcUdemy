using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoMvcUdemy.Models;

namespace CursoMvcUdemy.Controllers {
  public class ProdutoController : Controller {
    public IActionResult Index() {
      ViewBag.ListaProdutos = ProdutoModel.ListarTodos();
      return View();
    }

    [HttpGet]
    public IActionResult Cadastrar() {
      return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(ProdutoModel produto) {
      if(ModelState.IsValid) {
        produto.InsertEdit();
        return RedirectToAction("Index", "Produto");
      }
      return View();
    }

    [HttpGet]
    public IActionResult Editar(int id) {
      ViewBag.Produto = ProdutoModel.ListaProduto(id);
      return View();
    }

    [HttpPost]
    public IActionResult Editar(ProdutoModel produto) {
      if(ModelState.IsValid) {
        produto.InsertEdit();
        return RedirectToAction("Index", "Produto");
      }
      return View();
    }

    [HttpGet]
    public IActionResult ConfirmarDel(int? id) {
      ViewBag.IdProduto = id;
      return View();
    }

    [HttpGet]
    public void Deletar(int id) {
      ProdutoModel.Deletar(id);
      Response.Redirect("/Produto/Index");
    }



  }
}
