using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Financeiro.WebUI.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cards = await _cardService.GetCards();
            return View(cards);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CardDTO cardDto)
        {
            if(ModelState.IsValid)
            {
                await _cardService.Create(cardDto);
                return RedirectToAction(nameof(Index));
            }
            
            return View(cardDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}