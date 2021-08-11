using Rock_Paper_Scissors.Models;
using System;

namespace Rock_Paper_Scissors
{
    public interface IInputFactory
    {
        public string GetName();
        public Move GetHumanMove();
        public Move GetComputerMove();
    }
    public class InputFactory: IInputFactory
    {
        public string GetName()
        {
            Console.WriteLine("Hello and welcome to my Rock, Paper, Scissors game!");
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Welcome to game {0}.", name);
            return name;
        }

        public Move GetHumanMove()
        {
            Console.WriteLine("R - Rock\n" +
                              "P - Paper\n" +
                              "S - Scissors\n" +
                              "Make your selection: ");
            string input = Console.ReadLine();
            Move userMove = input.ToMove();
            if (userMove == Move.Default)
            {
                Console.WriteLine("Sorry Invalid. Please choose, try again");
                return GetHumanMove();
            }
            return userMove;
        }

        public Move GetComputerMove()
        {
            Random randomChoice = new Random();
            string input = randomChoice.Next(1, 4).ToString();

            Move computerMove = input.ToMove();
            Console.WriteLine($"Computer Selected {computerMove}");
            return computerMove;
        }
    }
}
