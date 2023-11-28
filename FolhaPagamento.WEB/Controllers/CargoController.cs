using FolhaPagamento.WEB.Models;
using FolhaPagamento.WEB.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace FolhaPagamento.WEB.Controllers
{
    public class CargoController : Controller
    {
        public string BaseUrl = "http://localhost:5256/api";
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("cargo/list")]
        public async Task<IActionResult> All()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ApiService.BaseUrl}/cargos");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            List<CargoViewModel> cargos = JsonSerializer.Deserialize<List<CargoViewModel>>(content)!;

            return View(cargos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}