using Prism.Mvvm;
using System.Collections.Generic;

namespace Shared.Models
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

        public Card()
        {

        }

        public Card(string name) : this()
        {
            Name = name;
        }

        public int Value()
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

    }
}
