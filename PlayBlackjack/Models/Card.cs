using Prism.Mvvm;
using System.Collections.Generic;

namespace PlayBlackjackModule.Models
{
    public class Card : BindableBase
    {
        public static readonly List<string> Faces = new List<string>() { "a", "2", "3", "4", "5", "6", "7", "8", "9", "t", "j", "q", "k" };
        public static readonly List<string> Suits = new List<string>() { "c", "s", "h", "d" };
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }

        public Card(string name)
        {
            Name = name;
            SetImageSource();
        }

        public int value()
        {
            int value;
            var card = Name[0];
            if (card == 't' || card == 'j' || card == 'q' || card == 'k')
            {
                value = 10;
            }
            else if (card == 'a')
            {
                value = 1;
            }
            else
            {
                value = card - '0';
            }
            return value;
        }

        public bool IsAce()
        {
            return Name[0] == 'a';
        }

        public override string ToString()
        {
            return $"Resources/{Name}.png";
        }

        private void SetImageSource()
        {
            ImageSource = ToString();
        }

    }
}
