using FolhaPagamento.WEB.Models;
using FolhaPagamento.WEB.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FolhaPagamento.WEB.Controllers
{
    public class ColaboradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("colaborador/list")]
        public async Task<IActionResult> All()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ApiService.BaseUrl}/colaboradores");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            List<ColaboradorViewModel> colaboradores = JsonSerializer.Deserialize<List<ColaboradorViewModel>>(content)!;

            return View(colaboradores);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine($"Colaborador: {id}");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{ApiService.BaseUrl}/colaboradores/{id}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("All");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}