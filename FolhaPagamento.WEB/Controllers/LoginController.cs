using FolhaPagamento.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FolhaPagamento.WEB.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Auth(string email, string senha)
        {
            string userMail = "test@domain.com";
            string pass = "123456";
            if(email == userMail && senha == pass)
            {
                return Redirect("/home");
            }

            ViewBag.Error = "E-mail ou senha incorretos.";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}