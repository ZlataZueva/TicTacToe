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
            if (firstName == string.Empty)
            {
                throw new ArgumentException("Player's first name should not be empty");
            }
            if (lastName == string.Empty)
            {
                throw new ArgumentException("Player's last name should not be empty");
            }
            if (firstName.ToCharArray().All(char.IsLetter))
            {
                throw new ArgumentException("Player's first name should contain letters only");
            }
            if (lastName.ToCharArray().All(char.IsLetter))
            {
                throw new ArgumentException("Player's last name should contain letters only");
            }

            return new Player(firstName, lastName, figureType);
        }
    }
}