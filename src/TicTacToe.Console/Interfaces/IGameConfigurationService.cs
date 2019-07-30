using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.GameConfiguration;

namespace TicTacToe.Console.Interfaces
{
    public interface IGameConfigurationService
    {
        IGameConfiguration PrepareGameConfiguration(
            ConfigurationCreationMode mode = ConfigurationCreationMode.NewPlayers,
            IGameConfiguration existentConfiguration = null);
    }
}