using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul._14
{
    public class Game
    {
        private List<Player> players = new List<Player>();
        private List<Karta> deck = new List<Karta>();
        internal IEnumerable<object> Players;

        public Game(List<string> playerNames)
        {
            players = playerNames.Select(name => new Player(name)).ToList();
            InitializeDeck();
            ShuffleDeck();
            DealCards();
        }

        private void InitializeDeck()
        {
            string[] masts = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] tips = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var mast in masts)
            {
                foreach (var tip in tips)
                {
                    deck.Add(new Karta(mast, tip));
                }
            }
        }

        private void ShuffleDeck()
        {
            Random random = new Random();
            deck = deck.OrderBy(x => random.Next()).ToList();
        }

        private void DealCards()
        {
            int numberOfPlayers = players.Count;
            int cardsPerPlayer = deck.Count / numberOfPlayers;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i].Cards.AddRange(deck.GetRange(i * cardsPerPlayer, cardsPerPlayer));
            }
        }

        public void Play()
        {
            while (players.All(player => player.Cards.Count > 0))
            {
                List<Karta> cardsInPlay = players.Select(player => player.Cards[0]).ToList();
                Console.WriteLine($"Cards in play: {string.Join(", ", cardsInPlay.Select(karta => $"{karta.Tip} {karta.Mast}"))}");

                int maxCardIndex = cardsInPlay.IndexOf(cardsInPlay.Max());
                Player roundWinner = players[maxCardIndex];

                Console.WriteLine($"{roundWinner.Name} wins the round!");

                players.ForEach(player => player.Cards.RemoveAt(0));
                roundWinner.Cards.AddRange(cardsInPlay);

                foreach (var player in players)
                {
                    player.DisplayCards();
                }
                Console.WriteLine();
            }

            Player gameWinner = players.Single(player => player.Cards.Count == 36);
            Console.WriteLine($"{gameWinner.Name} wins the game!");
        }
    
}
}
