using System;

namespace Rock_Paper_Scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputFactory factory = new InputFactory();
            new Game(factory).Start();
            Console.WriteLine("Game End!");
        }
    }
}
