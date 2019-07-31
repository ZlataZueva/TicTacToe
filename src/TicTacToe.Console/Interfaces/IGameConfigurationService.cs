using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.GameConfiguration;

namespace TicTacToe.Console.Interfaces
{
    public interface IGameConfigurationService
    {
        IGameConfiguration CreateGameConfiguration(
            ConfigurationCreationMode mode = ConfigurationCreationMode.NewPlayers,
            IGameConfiguration existingConfiguration = null);
    }
}