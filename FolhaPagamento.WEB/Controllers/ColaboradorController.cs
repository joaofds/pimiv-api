using FolhaPagamento.WEB.Models;
using FolhaPagamento.WEB.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace FolhaPagamento.WEB.Controllers
{
    public class ColaboradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            int cargoId, 
            string nome, 
            string cpf,
            string dataAdmissao
        )
        {

            var colaborador = new ColaboradorViewModel();
            colaborador.CargoId = cargoId;
            colaborador.nome = nome;
            colaborador.cpf = cpf;
            colaborador.dataAdmissao = dataAdmissao;
            string json = JsonSerializer.Serialize(colaborador);

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{ApiService.BaseUrl}/colaboradores");
            var content = new StringContent(json, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();


            return RedirectToAction("All");


            //if (response.StatusCode.Equals(200))
            //{
            //    return RedirectToAction("All");
            //}

            //ViewBag.Error = "Oops, erro ao tentar cadastrar colaborador.";
            //return View();
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