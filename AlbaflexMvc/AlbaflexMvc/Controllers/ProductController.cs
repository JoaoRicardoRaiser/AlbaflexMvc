using AlbaflexMvc.Data.Interfaces;
using AlbaflexMvc.Models;
using AlbaflexMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlbaflexMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductController(
            ILogger<ProductController> logger,
            IProductRepository productRepository,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IProductRepository productRepository)
        {
            return View(await productRepository.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
                return View(inputModel);
            
            try
            {
                await _productService.CreateAsync(inputModel);

                TempData["SucessMessage"] = "Produto cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["ErrorMessage"] = $"Ops, não foi possível cadastrar o produto, tente novamente. \n Detalhes do erro: {e.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromQuery] int code)
        {
            var product = await _productRepository.GetByCodeAsync(code);
            return View(product?.ToInputModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
                return View(inputModel);

            try
            {
                await _productService.EditAsync(inputModel);
                TempData["SucessMessage"] = "Produto editado com sucesso";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["ErrorMessage"] = $"Ops, não foi possível editar o produto, tente novamente. \n Detalhes do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeleteConfirmation(int code)
        {
            var product = await _productRepository.GetByCodeAsync(code);
            return View(product?.ToInputModel());
        }

        public async Task<IActionResult> Delete(int code)
        {
            try
            {
                await _productService.DeleteAsync(code);
                TempData["SucessMessage"] = "Produto excluido com sucesso";
                return RedirectToAction("Index");

            }
            catch(Exception e)
            {
                TempData["ErrorMessage"] = $"Ops, não foi possível excluir o produto, tente novamente. \n Detalhes do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
