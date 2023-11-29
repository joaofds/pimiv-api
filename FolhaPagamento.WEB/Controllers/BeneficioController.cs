using FolhaPagamento.WEB.Models;
using FolhaPagamento.WEB.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace FolhaPagamento.WEB.Controllers
{
    public class BeneficioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("beneficio/list")]
        public async Task<IActionResult> All()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ApiService.BaseUrl}/beneficios");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            List<BeneficioViewModel> beneficios = JsonSerializer.Deserialize<List<BeneficioViewModel>>(content)!;

            return View(beneficios);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{ApiService.BaseUrl}/beneficios/{id}");
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