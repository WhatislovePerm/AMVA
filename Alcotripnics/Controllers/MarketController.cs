using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Alcotripnics.Data.Entity;
using Alcotripnics.WebApp.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alcotripnics.WebApp.Controllers
{
    [Authorize()]
    public class MarketController : Controller
    {
        private IOfferRepository _offerRepository;

        private UserManager<Account> _userManager;

        private IPrincipal _principal;

        private ILogger<MarketController> _logger;

        private IAccountCardRepository _accountCardRepository;
        // GET: /<controller>/

        public MarketController(IOfferRepository offerRepository,
            ILogger<MarketController> logger,
            UserManager<Account> userManager,
            IPrincipal principal,
            IAccountCardRepository accountCardRepository)
        {
            _logger = logger;
            _offerRepository = offerRepository;
            _userManager = userManager;
            _principal = principal;
            _accountCardRepository = accountCardRepository;

        }

        public IActionResult Index()
        {
            var offers = _offerRepository.GetAllNotFinished();


            return View(offers.Result);

        }

        [HttpPost]
        public IActionResult Buy(long offerid)
        {
            if (offerid == 0)
                return View();

            var offerResult = _offerRepository.GetById(offerid);
            var offer = offerResult.Result;

            var customerName = _principal.Identity.Name;

            var customer =  _userManager.FindByNameAsync(customerName).Result;

            if (offer.Seller.Id == customer.Id)
            {
                offer.DateOfFinishing = DateTime.Now;
                var accountCard = _accountCardRepository.GetByCardAndAccountIdsForReturn(offer.Card.Id, customer.Id);

                accountCard.Result.DateOfDelete = null;
                _offerRepository.Update(offer);
                return RedirectToAction("Index", "Inventory");
            }

            if (customer.MoneyAmount - offer.Price < 0)
                return View();

            offer.Customer = customer;
            customer.MoneyAmount -= offer.Price;
            offer.Seller.MoneyAmount += offer.Price;
            offer.DateOfFinishing = DateTime.Now;


            //var sellerAccountCard = _accountCardRepository.GetByCardAndAccountIds(offer.Card.Id, offer.Seller.Id);
            //sellerAccountCard.Result.DateOfDelete = DateTime.Now;
            var customerAccountCard = new AccountCards() {
                Account = customer,
                AccountId = customer.Id,
                Card = offer.Card,
                CardId = offer.Card.Id };

            _accountCardRepository.Add(customerAccountCard);

            return RedirectToAction("Index", "Inventory");
        }


    }
}

