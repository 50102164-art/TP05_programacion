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

        if (UsuarioNuevo == null || string.IsNullOrWhiteSpace(UsuarioNuevo.NombreUsuarios))
        {
            return View();
        }

        var usuario = bd.ObtenerUsuarioPorCredenciales(UsuarioNuevo.NombreUsuarios, UsuarioNuevo.Contraseña);
        if (usuario != null)
        {
            HttpContext.Session.SetString("IdUsuarioNuevo", usuario.IdUsuario.ToString());
            HttpContext.Session.SetString("UsuarioNombre", usuario.NombreUsuarios ?? string.Empty);
            return View("PrivateHTML");
        }
        else
        {
            ViewBag.Error = "Credenciales inválidas";
            return View();
        }
    }

    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    public IActionResult Registrarse(Usuarios UsuarioNuevo, Domicilio DomicilioNuevo)
    {
        BD bd = new BD();

        if (UsuarioNuevo == null || DomicilioNuevo == null)
        {
            return View();
        }

        bool existe = bd.BuscarSiExisteUnUsuario(UsuarioNuevo.NombreUsuarios);
        if (existe)
        {
            ViewBag.Error = "El nombre de usuario ya existe";
            ViewBag.UsuarioNuevo = UsuarioNuevo;
            return View("Registrarse");
        }
        else
        {
            ViewBag.UsuarioNuevo = UsuarioNuevo;
            ViewBag.DomicilioNuevo = DomicilioNuevo;
            bd.RegistrarDomicilio(DomicilioNuevo);
            bd.RegistrarUsuarios(UsuarioNuevo);
            return View("IniciarSesion");
        }
    }

    public IActionResult GuardarUsuario(Usuarios UsuarioNuevo)
    {
        BD bd = new BD();
        if (UsuarioNuevo.usuariosRepetidos(UsuarioNuevo))
        {
            int nuevoId = bd.RegistrarUsuariosRetornandoId(UsuarioNuevo);
            HttpContext.Session.SetString("IdUsuarioNuevo", nuevoId.ToString());
            HttpContext.Session.SetString("UsuarioNombre", UsuarioNuevo.NombreUsuarios ?? string.Empty);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Error = "El usuario ya existe";
            return RedirectToAction("Registrarse", "Home");
        }
    }

    //Crea una funcion para guardar el domicilio en la base de datos si el domicilio no existe, sino muestra un mensaje de error.
    public IActionResult GuardarDomicilio(Domicilio DomicilioNuevo)
    {
        BD bd = new BD();
        if (DomicilioNuevo.domiciliosRepetidos(DomicilioNuevo))
        {
            // Aquí puedes agregar la lógica para guardar el domicilio en la base de datos si es necesario
            return View("Index");
        }
        else
        {
            ViewBag.Error = "El domicilio ya existe";
            return View("Registrarse");
        }
    }
}
