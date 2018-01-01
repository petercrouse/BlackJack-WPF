﻿using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace PlayBlackjackModule.Models
{
    public class Hand : BindableBase
    {
        private ObservableCollection<Card> _cardsInHand;
        public ObservableCollection<Card> CardsInHand
        {
            get { return _cardsInHand; }
            set { SetProperty(ref _cardsInHand, value); }
        }

        public Hand()
        {
            CardsInHand = new ObservableCollection<Card>();
        }

        public void AddCard(Card card)
        {
            CardsInHand.Add(card);
        }

        public int handValue()
        {
            int score = 0;
            bool ace = false;

            foreach(var card in CardsInHand)
            {
                score += card.value();
                if (card.IsAce())
                {
                    ace = true;
                }
            }
            if(ace && (score + 10) <= 21)
            {
                score += 10;
            }
            return score;
        }

        public void clearHand()
        {
            CardsInHand.Clear();
        }

        public void SetHandToCardbackImages()
        {
            foreach (var card in CardsInHand)
            {
                card.ImageSource = $"Resources/cb.png";
            }
        }

        public void SetHandCardFaceImages()
        {
            foreach (var card in CardsInHand)
            {
                card.SetImageSource();
            }
        }
    }
}