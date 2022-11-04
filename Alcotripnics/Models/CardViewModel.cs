using System;
using Alcotripnics.Data.Entity;
using Alcotripnics.WebApp.Enums;

namespace Alcotripnics.Models
{
    public class CardViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string ImageSource { get; set; }

        public string Name { get; set; }

        public CardRarityEnum CardRarityEnum { get; set; }

        public CardViewModel(Card card)
        {
            Id = card.Id;
            Title = card.Title;
            ImageSource = card.ImageSource;
            CardRarityEnum = card.CardRarityEnum;
            Name = card.Name;
        }

       /* public static List<CardViewModel> CreateSample()
        {
            return
                new List<CardViewModel>()
                {
                    new CardViewModel(1, "Он еще не знает, что пандемию отменили", "../Images/Maxim1.jpeg", "Максим в маске", CardRarityEnum.primary){},
                    new CardViewModel(2, "Как же горячо", "../Images/Ilya1.jpeg", "Илья с киской", CardRarityEnum.warning){},

                };
        }*/
    }

}

