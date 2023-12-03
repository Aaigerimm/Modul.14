using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul._14
{
    public class Player
    {
        public string Name { get; }
        public List<Karta> Cards { get; } = new List<Karta>();

        public Player(string name)
        {
            Name = name;
        }

        public void DisplayCards()
        {
            Console.WriteLine($"{Name}'s cards: {string.Join(", ", Cards.Select(karta => $"{karta.Tip} {karta.Mast}"))}");
        }

    }
}
