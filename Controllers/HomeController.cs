using CursoMvcUdemy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMvcUdemy.Controllers {
  public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger) {
      _logger = logger;
    }

    public IActionResult Index() {
      return View();
    }

    public IActionResult Privacy() {
      return View();
    }

    [HttpGet]
    public IActionResult Login(int? id) {
      if(id != null) {
        if(id == 0) {
          HttpContext.Session.SetString("LoginAutenticado", string.Empty);
          HttpContext.Session.SetString("IdAutenticado", string.Empty);
        }
      }
      return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel userteste) {
      if(ModelState.IsValid) {
        if(userteste.BuscarUsuario()) {
          HttpContext.Session.SetString("LoginAutenticado", userteste.Login);
          HttpContext.Session.SetString("IdAutenticado", userteste.Id.ToString());
          return RedirectToAction("Menu", "Home");
        } else {
          TempData["ErrorLogin"] = "Login ou senha inválido";
        }
      }
      return View();
    }

    public IActionResult Menu() {
      return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
