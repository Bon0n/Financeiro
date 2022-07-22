using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Financeiro.WebUI.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var purchases = await _purchaseService.GetPurchases();
            return View(purchases);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseDTO purchaseDto)
        {
            if(ModelState.IsValid)
            {
                await _purchaseService.Create(purchaseDto);
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}