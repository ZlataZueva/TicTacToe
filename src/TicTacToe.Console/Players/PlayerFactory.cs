using System;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.Players
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string firstName, string lastName, FigureType figureType)
        {
            if (String.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("Player's first name should not be empty");
            }
            if (String.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Player's last name should not be empty");
            }
            
            return new Player(firstName, lastName, figureType);
        }
    }
}