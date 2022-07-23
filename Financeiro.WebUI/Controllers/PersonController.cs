using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Financeiro.WebUI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IBankService _bankService;

        public PersonController(IPersonService personService, IBankService bankService)
        {
            _personService = personService;
            _bankService = bankService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var people = await _personService.GetPeople();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonDTO personDto)
        {
            if(ModelState.IsValid)
            {
                await _personService.Create(personDto);
                return RedirectToAction(nameof(Index));
            }
            return View(personDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var personDto = await _personService.GetById(id);
            return View(personDto);
        }

        [HttpGet]
        public async Task<IActionResult> Finances(int? id)
        {
            var bankDto = await _bankService.GetBankPersonId(id);
            var personDto = await _personService.GetBanks(id);
            return View(personDto);
        }
    }
}