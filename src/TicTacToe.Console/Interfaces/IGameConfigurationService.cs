using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IGameConfigurationService
    {
        IGameConfiguration CreateGameConfiguration(IGameConfiguration existingConfiguration = null);
    }
}