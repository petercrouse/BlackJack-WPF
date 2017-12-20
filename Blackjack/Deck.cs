using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck : Notifier
    {
        private ObservableCollection<Card> _myDeck;
        public ObservableCollection<Card> MyDeck
        {
            get { return _myDeck; }
            set
            {
                _myDeck = value;
                OnPropertyChanged("MyDeck");
            }
        }

        public Deck()
        {
            MyDeck = new ObservableCollection<Card>();
            reset();
        }

        public Card pick()
        {
            Random random = new Random();
            int randomChoice = random.Next(CardsLeft());
            Card card = MyDeck[randomChoice];
            MyDeck.RemoveAt(randomChoice);
            return card;
        }

        public void reset()
        {
            if(MyDeck != null) MyDeck.Clear();
            int suits = 4, cards = 13;
            for (int i = 0; i < suits; i++)
            {
                for (int j = 0; j < cards; j++)
                {
                    var name = $"{Card.Faces[j]}{Card.Suits[i]}";
                    MyDeck.Add(new Card(name));
                }
            }
        }

        public override string ToString()
        {
            string cards = "";

            foreach(var card in MyDeck)
            {
                cards += $"{card.Name}\n";
            }
            return cards;
        }

        public int CardsLeft()
        {
            return MyDeck.Count;
        }
    }
}
