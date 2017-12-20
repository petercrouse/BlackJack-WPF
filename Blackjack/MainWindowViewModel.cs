using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blackjack
{
    public class MainWindowViewModel : Notifier
    {
        #region Properties
        private Hand _playerHand;
        public Hand PlayerHand { get; private set; }
        private Hand _dealerHand;
        public Hand DealerHand { get; private set; }

        private int _cardsInDeck;
        public int CardsInDeck
        {
            get { return _cardsInDeck; }
            set
            {
                _cardsInDeck = value;
                OnPropertyChanged("CardsInDeck");
            }
        }

        private int _playerScore;
        public int PlayerScore
        {
            get { return _playerScore; }
            set
            {
                _playerScore = value;
                OnPropertyChanged("PlayerScore");
            }
        }
        private int _dealerScore;
        public int DealerScore
        {
            get { return _dealerScore; }
            set
            {
                _dealerScore = value;
                OnPropertyChanged("DealerScore");
            }
        }
        private Deck _myDeck;
        public Deck MyDeck
        {
            get { return _myDeck; }
            set
            {
                _myDeck = value;
                OnPropertyChanged("MyDeck");
            }
        }
        #endregion  
        public MainWindowViewModel()
        {
            PlayerHand = new Hand();
            DealerHand = new Hand();
            PlayerScore = 0;
            DealerScore = 0;
            MyDeck = new Deck();
            CardsInDeck = MyDeck.CardsLeft();
            NewGame();
        }
        
        public void DealHands()
        {
            PlayerHand.clearHand();
            DealerHand.clearHand();
            PlayerHand.AddCard(MyDeck.pick());
            PlayerHand.AddCard(MyDeck.pick());
            DealerHand.AddCard(MyDeck.pick());
            DealerHand.AddCard(MyDeck.pick());
            CardsInDeck = MyDeck.CardsLeft();
        }
        public void NewGame()
        {
            MyDeck.reset();
            CardsInDeck = MyDeck.CardsLeft();
            PlayerHand.clearHand();
            DealerHand.clearHand();       
        }

        public void Hit()
        {
            PlayerHand.AddCard(MyDeck.pick());

            if (PlayerHand.handValue() > 21)
            {
                MessageBox.Show("Busted! you lose.");
                DealerScore++;
            }
            if (PlayerHand.handValue() < 21 && PlayerHand.CardsInHand.Count >= 5)
            {
                MessageBox.Show("Player wins!");
                PlayerScore++;
            }
            CardsInDeck = MyDeck.CardsLeft();
        }

        public void Stay()
        {
            PlayerScore = PlayerHand.handValue();
            DealerScore = DealerHand.handValue();

            while (DealerScore < 18)
            {
                DealerHand.AddCard(MyDeck.pick());
                DealerScore = DealerHand.handValue();
            }

            string winner = (DealerScore >= PlayerScore && DealerScore <= 21) ? "Dealer wins!" : "Player wins!";
            MessageBox.Show(winner);
            if (winner == "Dealer wins")
            {
                DealerScore++;
            }
            else
            {
                PlayerScore++;
            }
        }

        public void SuffleDeck()
        {
            MyDeck.reset();
        }
    }
}
