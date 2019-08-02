using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string firstName, string lastName, FigureType figureType);
    }
}