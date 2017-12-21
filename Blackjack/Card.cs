using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        public static readonly List<string> Faces = new List<string>() { "a", "1", "2", "3", "4", "5", "6", "7", "8", "9", "t", "j", "q", "k" };
        public static readonly List<string> Suits = new List<string>() { "c", "s", "h", "d" };
        public string Name { get; set; }
        public string ImageSource { get; set; }

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
