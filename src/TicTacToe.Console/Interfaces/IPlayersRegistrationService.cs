using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Console.Interfaces
{
    public interface IPlayersRegistrationService
    {
        IPlayer Register(IReadOnlyList<FigureType> availableFigureTypes);
    }
}