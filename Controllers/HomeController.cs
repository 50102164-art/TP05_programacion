using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05.Models;

namespace TP05.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult IniciarSesion(Usuarios UsuarioNuevo)
    {
        BD bd = new BD();
        ViewBag.UsuarioNuevo = UsuarioNuevo;
        return View();
    }
    public IActionResult CerrarSesion(Usuarios UsuarioNuevo)
    {
        ViewBag.UsuarioNuevo = UsuarioNuevo;
        return View();
    }

    public IActionResult Registrarse(Usuarios UsuarioNuevo, List<Usuarios> Users)
    {
        int i = 0;
        while(UsuarioNuevo.usuariosRepetidos(UsuarioNuevo) == false && i < Users.Count)
        {
            i++;
        }
        if(i < Users.Count)
        {
            ViewBag.UsuarioNuevo = UsuarioNuevo;
            return View("RegistrarUsuario");
        }
        HttpContext.Session.SetString("IdUsuarioNuevo", UsuarioNuevo.IdUsuario.ToString());
        ViewBag.UsuarioNuevo = UsuarioNuevo;
        return View();
    }

    public IActionResult GuardarUsuario(Usuarios UsuarioNuevo)
    {
        BD bd = new BD();
        if(UsuarioNuevo.usuariosRepetidos(UsuarioNuevo)){
            bd.RegistrarUsuarios(UsuarioNuevo);
            return RedirectToAction("IniciarSesion", "Home");
        }else{
            return RedirectToAction("RegistrarUsuarios", "Home");
        }
    }
}
