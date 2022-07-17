using Financeiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Financeiro.WebUI.Controllers
{
    [Route("cards")]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task<IActionResult> Index()
        {
            var cards = await _cardService.GetCards();
            return View(cards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}