using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class HandViewModel : Notifier
    {
        private ObservableCollection<Card> _cardsInHand;
        public ObservableCollection<Card> CardsInHand
        {
            get { return _cardsInHand; }
            set
            {
                _cardsInHand = value;
                OnPropertyChanged("CardsInHand");
            }
        }

        public HandViewModel()
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

    }
}
