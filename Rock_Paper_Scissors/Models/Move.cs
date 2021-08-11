namespace Rock_Paper_Scissors.Models
{
    public enum Move
    {
        Default = 0,
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public static class MoveMapper
    {
        public static Move ToMove<T>(this T move)
        {
            string choice = move.ToString();
            switch (choice.ToUpper())
            {
                case "R":
                case "1":
                    return Move.Rock;
                case "P":
                case "2":
                    return Move.Paper;
                case "S":
                case "3":
                    return Move.Scissors;

            }

            return Move.Default;
        }
    }
}
