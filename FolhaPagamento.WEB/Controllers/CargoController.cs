using FolhaPagamento.WEB.Models;
using FolhaPagamento.WEB.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace FolhaPagamento.WEB.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nome, float salario)
        {
            var cargo = new CargoViewModel();
            cargo.Nome = nome;
            cargo.Salario = salario;
            string json = JsonSerializer.Serialize(cargo);

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{ApiService.BaseUrl}/cargos");
            var content = new StringContent(json, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{ApiService.BaseUrl}/cargos/{id}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("All");
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