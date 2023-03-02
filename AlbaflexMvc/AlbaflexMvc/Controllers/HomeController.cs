using AlbaflexMvc.Models;
using AlbaflexMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Text;

namespace AlbaflexMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var budgetInformation = await _productService.GetBudgetInformation();
            //ViewData["Tissues"] = .Select(x => new SelectListItem(x.Code.ToString(), $"{x.Code} - {x.Description}"));
            //ViewData["Materials"] = budgetInformation.Materials.Select(x => new SelectListItem(x.Code.ToString(), $"{x.Code} - {x.Description}"));

            ViewData["Tissues"] = budgetInformation.Tissues.Select(c => new SelectListItem() { Text = c.Description, Value = c.Code.ToString()}).ToList();
            ViewData["Materials"] = budgetInformation.Materials.Select(c => new SelectListItem() { Text = c.Description, Value = c.Code.ToString()}).ToList();
            ViewData["CaixaBox"] = budgetInformation.CaixaBox.Select(c => new SelectListItem() { Text = c.Description, Value = c.Code.ToString()}).ToList();
            return View();
        }

        [HttpPost("teste")]
        public async Task<IActionResult> CreateBudget()
        {
            await _productService.GenerateBudgetPdf();
            return Ok();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}