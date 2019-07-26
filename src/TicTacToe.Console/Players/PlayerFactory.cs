using System;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.Players
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string firstName, string lastName, FigureType figureType)
        {
            if (firstName == string.Empty || lastName == string.Empty)
            {
                throw new ArgumentException("Player's first and last names should not be empty");
            }
            if (firstName.ToCharArray().Any(char.IsDigit) || lastName.ToCharArray().Any(char.IsDigit))
            {
                throw new ArgumentException("Player's first and last names should not contain digits");
            }

            return new Player(firstName, lastName, figureType);
        }
    }
}