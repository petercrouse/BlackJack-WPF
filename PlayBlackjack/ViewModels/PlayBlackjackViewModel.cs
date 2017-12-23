using Prism.Mvvm;
using PlayBlackjackModule.Models;
using System.Windows;

namespace PlayBlackjackModule.ViewModels
{
    public class PlayBlackjackViewModel : BindableBase
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
            set { SetProperty(ref _cardsInDeck, value); }
        }

        private int _playerScore;
        public int PlayerScore
        {
            get { return _playerScore; }
            set { SetProperty(ref _playerScore, value); }
        }
        private int _dealerScore;
        public int DealerScore
        {
            get { return _dealerScore; }
            set { SetProperty(ref _dealerScore, value); }
        }
        private Deck _myDeck;
        public Deck MyDeck
        {
            get { return _myDeck; }
            set { SetProperty(ref _myDeck, value); }
        }
        #endregion  

        public PlayBlackjackViewModel()
        {
            PlayerHand = new Hand();
            DealerHand = new Hand();
            PlayerScore = 0;
            DealerScore = 0;
            MyDeck = new Deck();
            CardsInDeck = MyDeck.CardsLeft();
            NewGame();
        }

        #region methods
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
            var pScore = PlayerHand.handValue();
            var dScore = DealerHand.handValue();

            while (dScore < 18)
            {
                DealerHand.AddCard(MyDeck.pick());
                dScore = DealerHand.handValue();
            }

            string winner = (dScore >= pScore && dScore <= 21) ? "Dealer wins!" : "Player wins!";
            MessageBox.Show($"Player: {pScore} Dealer: {dScore}\n\n{winner}");
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
            CardsInDeck = MyDeck.CardsLeft();
        }

        public void Quit()
        {
            Application.Current.Shutdown();
        }

        #endregion

    }


}
