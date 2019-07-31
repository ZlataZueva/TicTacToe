using iTechArt.TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Console.Interfaces
{
    public interface IGameConfigurationService
    {
        IGameConfiguration CreateGameConfiguration(IGameConfiguration existingConfiguration = null);
    }
}