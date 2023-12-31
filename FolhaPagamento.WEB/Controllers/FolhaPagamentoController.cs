﻿using FolhaPagamento.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FolhaPagamento.WEB.Controllers
{
    public class FolhaPagamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("folhapagamento/list")]
        public IActionResult All()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}