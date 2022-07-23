using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Financeiro.WebUI.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var banks = await _bankService.GetBanks();
            return View(banks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BankDTO bankDto)
        {
            if(ModelState.IsValid)
            {
                await _bankService.Create(bankDto);
                return RedirectToAction(nameof(Index));
            }
            return View(bankDto);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var bankDto = await _bankService.GetBankPersonId(id);
            return View(bankDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}