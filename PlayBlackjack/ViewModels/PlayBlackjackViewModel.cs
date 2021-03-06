﻿using System.Windows;
using Prism.Commands;
using Prism.Regions;
using Shared.ViewModels;
using Prism.Events;
using Shared.Models;
using Shared.Events;

namespace PlayBlackjackModule.ViewModels
{
    public class PlayBlackjackViewModel : GameViewModel
    {
        #region Properties
        public Hand PlayerHand { get; private set; }
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
        private int _playerHandValue;
        public int PlayerHandValue
        {
            get { return _playerHandValue; }
            set { SetProperty(ref _playerHandValue, value); }
        }
        private int _dealerHandValue;
        public int DealerHandValue
        {
            get { return _dealerHandValue; }
            set { SetProperty(ref _dealerHandValue, value); }
        }
        private bool _dealHandsButtonVisible;
        public bool DealHandsButtonVisible
        {
            get { return _dealHandsButtonVisible; }
            set { SetProperty(ref _dealHandsButtonVisible, value); }
        }
        private bool _hitButtonVisible;
        public bool HitButtonVisible
        {
            get { return _hitButtonVisible; }
            set { SetProperty(ref _hitButtonVisible, value); }
        }
        private bool _stayButtonVisible;
        public bool StayButtonVisible
        {
            get { return _stayButtonVisible; }
            set { SetProperty(ref _stayButtonVisible, value); }
        }
        private bool _shuffleDeckButtonVisible;
        public bool ShuffleDeckButtonVisible
        {
            get { return _shuffleDeckButtonVisible; }
            set { SetProperty(ref _shuffleDeckButtonVisible, value); }
        }
        private string _messageBoard;
        public string MessageBoard
        {
            get { return _messageBoard; }
            set
            {
                SetProperty(ref _messageBoard, value);
                EventAggregator.GetEvent<GameMessageEvent>().Publish(_messageBoard);
            }
        }
        #endregion

        #region commands
        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand DealHandsCommand { get; private set; }
        public DelegateCommand HitCommand { get; private set; }
        public DelegateCommand StayCommand { get; private set; }
        public DelegateCommand ShuffleDeckCommand { get; private set; }
        public DelegateCommand QuitCommand { get; private set; }

        #endregion

        public PlayBlackjackViewModel(IRegionManager regionManager, IEventAggregator eventAggregator): base(regionManager, eventAggregator)
        {
            PlayerHand = new Hand();
            DealerHand = new Hand();
            PlayerScore = 0;
            DealerScore = 0;
            MyDeck = new Deck();
            CardsInDeck = MyDeck.CardsLeft();
            NewGameCommand = new DelegateCommand(NewGame);
            DealHandsCommand = new DelegateCommand(DealHands);
            HitCommand = new DelegateCommand(Hit);
            StayCommand = new DelegateCommand(Stay);
            ShuffleDeckCommand = new DelegateCommand(ShuffleDeck);
            QuitCommand = new DelegateCommand(Quit);
            StayButtonVisible = false;
            HitButtonVisible = false;
            DealHandsButtonVisible = false;
            ShuffleDeckButtonVisible = false;
            DealerHandValue = 0;
            PlayerHandValue = 0;
        }

        #region methods
        private void DealHands()
        {
            if (CardsInDeck < 10)
            {
                DealHandsButtonVisible = false;
                ShuffleDeckButtonVisible = true;
                MessageBoard = "There are not enough cards\n" +
                               "in the deck to play the hand.";
            }
            else
            {
                PlayerHand.clearHand();
                DealerHand.clearHand();
                PlayerHand.AddCard(MyDeck.pick());
                PlayerHand.AddCard(MyDeck.pick());
                DealerHand.AddCard(MyDeck.pick());
                DealerHand.AddCard(MyDeck.pick());

                HitButtonVisible = true;
                StayButtonVisible = true;
                ShuffleDeckButtonVisible = false;
                DealHandsButtonVisible = false;

                CardsInDeck = MyDeck.CardsLeft();
                DealerHandValue = 0;
                PlayerHandValue = 0;
                MessageBoard = "";
            }          
        }

        private void NewGame()
        {
            MyDeck.reset();
            CardsInDeck = MyDeck.CardsLeft();
            PlayerHand.clearHand();
            DealerHand.clearHand();

            ShuffleDeckButtonVisible = true;
            DealHandsButtonVisible = true;

            DealerHandValue = 0;
            PlayerHandValue = 0;
            PlayerScore = 0;
            DealerScore = 0;
            MessageBoard = "";
        }

        private void Hit()
        {
            bool endOfRound = false;
            PlayerHand.AddCard(MyDeck.pick());

            if (PlayerHand.handValue() > 21)
            {
                MessageBoard = "Busted! you lose.";
                DealerScore++;
                endOfRound = true;
            }
            if (PlayerHand.handValue() <= 21 && PlayerHand.CardsInHand.Count >= 5)
            {
                MessageBoard = "Player wins!";
                PlayerScore++;
                endOfRound = true;
            }
            if (endOfRound)
            {
                DealHandsButtonVisible = true;
                HitButtonVisible = false;
                StayButtonVisible = false;
                ShuffleDeckButtonVisible = true;
            }
            CardsInDeck = MyDeck.CardsLeft();
        }

        private void Stay()
        {
            PlayerHandValue = PlayerHand.handValue();
            DealerHandValue = DealerHand.handValue();

            bool dealerHas5CardsWithValueSmallerThan21 = false;
            int count = DealerHand.CardsInHand.Count;
            while (!dealerHas5CardsWithValueSmallerThan21 && DealerHandValue < 18)
            {
                DealerHand.AddCard(MyDeck.pick());
                DealerHandValue = DealerHand.handValue();
                count++;
                if (count == 5 && DealerHandValue <= 21)
                    dealerHas5CardsWithValueSmallerThan21 = true;
            }

            string winner = (dealerHas5CardsWithValueSmallerThan21 || 
                (DealerHandValue >= PlayerHandValue && DealerHandValue <= 21)) ? "Dealer wins!" : "Player wins!";

            if (DealerHandValue == PlayerHandValue && !dealerHas5CardsWithValueSmallerThan21)
            {
                winner = "It's a draw.";
            }

            MessageBoard = $"{winner}";

            if (winner == "Dealer wins!")
            {
                DealerScore++;
            }
            if (winner == "Player wins!")
            {
                PlayerScore++;
            }

            HitButtonVisible = false;
            StayButtonVisible = false;
            ShuffleDeckButtonVisible = true;
            DealHandsButtonVisible = true;
            CardsInDeck = MyDeck.CardsLeft();
        }

        private void ShuffleDeck()
        {
            MyDeck.reset();
            CardsInDeck = MyDeck.CardsLeft();
            MessageBoard = "";
            DealHandsButtonVisible = true;
        }

        private void Quit()
        {
            Application.Current.Shutdown();
        }

        #endregion

    }


}
