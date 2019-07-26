using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Console.Players
{
    public class Player : IPlayer
    {
        public string FirstName { get; }

        public string LastName { get; }

        public FigureType FigureType { get; }


        public Player(string firstName, string lastName, FigureType figureType)
        {
            FirstName = firstName;
            LastName = lastName;
            FigureType = figureType;
        }
    }
}