using Rock_Paper_Scissors.Models;
using System;
using System.Collections.Generic;

namespace Rock_Paper_Scissors
{
    public class Game
    {
        private Player _human = null;

        private readonly IInputFactory _factory = null;
        private readonly Player _computer = null;
        private readonly Dictionary<string, int> _winners = null;
        public Game(IInputFactory factory)
        {
            this._factory = factory;
            this._computer = new Player { Name = "Computer" };

            this._winners = new Dictionary<string, int>();
            this._winners.Add(this._computer.Name, 0);
        }

        /// <summary>
        /// Game Starting point
        /// </summary>
        public void Start()
        {
            string name = this._factory.GetName();
            this._human = new Player { Name = name };
            this._winners.Add(this._human.Name, 0);

            int match = 1;
            while (match <= 3)
            {
                Console.WriteLine("************************************************");
                Console.WriteLine($"\t\tMatch {match}");
                Console.WriteLine("************************************************");
                this._human.Move = this._factory.GetHumanMove();
                _computer.Move = this._factory.GetComputerMove();

                Player winner = this.GetWinner();
                if (null != winner)
                {
                    int oldValue = this._winners[winner.Name];
                    this._winners[winner.Name] = oldValue + 1;
                    Console.WriteLine($"{winner.Name} is the winner.");
                    match++;
                }
                else
                {
                    Console.WriteLine("Match Draw! let's try again");
                }

                Console.WriteLine("\n");
            }

            AnnounceWinner();
        }

        /// <summary>
        /// Winner announcer
        /// </summary>
        private void AnnounceWinner()
        {
            if (this._winners[this._human.Name] > this._winners[this._computer.Name])
                Console.WriteLine($"Congrats {this._human.Name} is the winner");
            else
                Console.WriteLine($"Congrats {this._computer.Name} is the winner");
        }

        /// <summary>
        /// ●	Rock beats scissors
        /// ●	Scissors beats paper
        /// ●	Paper beats rock
        /// </summary>
        /// <param name="move">move</param>
        /// <returns></returns>
        private static Move GetWinningMove(Move move)
        {
            switch (move)
            {
                case Move.Rock:
                    return Move.Paper; // Paper beats rock
                case Move.Paper:
                    return Move.Scissors; // Scissors beats paper
                case Move.Scissors:
                default:
                    return Move.Rock; //Rock beats scissors
            }
        }

        /// <summary>
        /// Get Winner
        /// </summary>
        /// <returns></returns>
        private Player GetWinner()
        {
            if (GetWinningMove(this._human.Move).Equals(this._computer.Move))
            {
                return this._computer;
            }
            else if (GetWinningMove(this._computer.Move).Equals(this._human.Move))
            {
                return this._human;
            }
            else
            {
                return null;
            }
        }
    }
}
