using System;
using System.ComponentModel.DataAnnotations;
using Alcotripnics.Data.Entity;
using Alcotripnics.WebApp.Enums;

namespace Alcotripnics.Models
{
    public class SellCardViewModel
    {
        public long CardId {get; set;}

        public string? ImageSource { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        [Display(Name="Цена")]
        public decimal? Price { get; set; }

        public int? CardRarityEnum { get; set; }

        public SellCardViewModel() { }

        public SellCardViewModel(Card card)
        {
            ImageSource = card.ImageSource;

            Title = card.Title;

            Name = card.Name;

            CardRarityEnum = ((int)card.CardRarityEnum);
        }
    }
}

