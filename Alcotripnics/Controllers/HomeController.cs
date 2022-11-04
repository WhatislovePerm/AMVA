using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Alcotripnics.Models;
using Alcotripnics.Data.Entity;
using Alcotripnics.WebApp.Data.Repository;
using Alcotripnics.WebApp.Enums;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace Alcotripnics.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ICardRepository _cardRepository;

    private readonly UserManager<Account> _userManager;

    private readonly IPrincipal _principal;

    private readonly IAccountCardRepository _accountCardRepository;


    public HomeController(
        ILogger<HomeController> logger,
        ICardRepository cardRepository,
        UserManager<Account> userManager,
        IPrincipal principal,
        IAccountCardRepository accountCardRepository)
    {
        _logger = logger;
        _cardRepository = cardRepository;
        _userManager = userManager;
        _principal = principal;
        _accountCardRepository = accountCardRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet, Route("OpenPack")]
    public IActionResult OpenPack()
    {
        var account = _userManager.FindByNameAsync(_principal.Identity.Name).Result;

        if (account.MoneyAmount <= 20)
            return View();

        var card = GetRandomCard();

        account.MoneyAmount -= 20;

        _accountCardRepository.Add(new AccountCards() { Account = account, Card = card, AccountId = account.Id, CardId = card.Id });

        return View(new CardViewModel(card));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private Card GetRandomCard()
    {
        var random = new Random();

        var randomNumber = random.Next(0, 101);

        var cards = new List<Card>();

        if (randomNumber <= 60)
            cards = _cardRepository.GetCardsWithRarity(CardRarityEnum.primary).Result.ToList();

        if (randomNumber > 60 && randomNumber <= 85)
            cards = _cardRepository.GetCardsWithRarity(CardRarityEnum.warning).Result.ToList();

        if (randomNumber > 85 && randomNumber <= 95)
            cards = _cardRepository.GetCardsWithRarity(CardRarityEnum.UltraRare).Result.ToList();

        if (randomNumber > 95)
            cards = _cardRepository.GetCardsWithRarity(CardRarityEnum.ULtimateRate).Result.ToList();

        var randomCardIndex = random.Next(0, cards.Count);

        var selectedCard = cards[randomCardIndex];

        return selectedCard;
    }

}

