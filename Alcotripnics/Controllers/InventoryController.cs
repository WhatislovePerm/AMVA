using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alcotripnics.WebApp.Data.Repository;
using Alcotripnics.Models;
using Microsoft.AspNetCore.Mvc;
using Alcotripnics.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alcotripnics.Controllers
{
    public class InventoryController : Controller
    {

        // GET: /<controller>/

        private readonly ILogger<InventoryController> _logger;

        private readonly ICardRepository _cardRepository;

        private readonly IAccountCardRepository _accountCardRepository;

        private readonly IOfferRepository _offerRepository;

        private readonly UserManager<Account> _userManager;

        private IPrincipal _principal;


        public InventoryController(
            ILogger<InventoryController> logger,
            ICardRepository cardRepository,
            IAccountCardRepository accountCardRepository,
            IOfferRepository offerRepository,
            UserManager<Account> userManager,
            IPrincipal principal)
        {
            _logger = logger;
            _cardRepository = cardRepository;
            _accountCardRepository = accountCardRepository;
            _offerRepository = offerRepository;
            _userManager = userManager;
            _principal = principal;
        }

        [Authorize()]
        public IActionResult Index()
        {
            //var cards = CardViewModel.CreateSample();
            var account = _userManager.FindByNameAsync(_principal.Identity.Name);

            var accountCards = _accountCardRepository.GetByAccountId(account.Result.Id).Result.Select(x => x.CardId);


            var cards = _cardRepository.GetAll().Result.Where(x => accountCards.Contains(x.Id));

            var cardsViewModel = new List<CardViewModel>();

            foreach(var accountCard in accountCards)
            {
                cardsViewModel.Add(new CardViewModel(cards.Where(x => x.Id == accountCard).FirstOrDefault()));
            }

            return View(cardsViewModel);
        }

        [HttpGet]
        public IActionResult SellCard(long cardid)
        {
            var card = _cardRepository.GetById(cardid).Result;

            return View(new SellCardViewModel(card));

        }


        [HttpPost]
        public IActionResult SellCard(SellCardViewModel sellCardViewModel)
        {
            var account =  _userManager.FindByNameAsync(_principal.Identity.Name);

            var accountCard = _accountCardRepository.GetByCardAndAccountIds(sellCardViewModel.CardId, account.Result.Id);

            if (accountCard.IsCanceled || accountCard.Result == null)
                return NotFound();

            var card = _cardRepository.GetById(sellCardViewModel.CardId);

            var newOffer = new Offer() { DateOfCreated = DateTime.Now, Seller = account.Result, Card = card.Result, Price = sellCardViewModel.Price.Value };

            accountCard.Result.DateOfDelete = DateTime.Now;

            _offerRepository.Add(newOffer);

            return RedirectToAction("Index", "Inventory");
            

        }
    }
}

