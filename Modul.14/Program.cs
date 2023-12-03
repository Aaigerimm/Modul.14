using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul._14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> playerNames = new List<string> { "Player1", "Player2" };
            Game game = new Game(playerNames);

            foreach (var player in game.Players)
            {
                object value = player.DisplayCards();
            }
        }
    }
}
