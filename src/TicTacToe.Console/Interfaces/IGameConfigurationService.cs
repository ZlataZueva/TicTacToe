using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.GameConfiguration;

namespace TicTacToe.Console.Interfaces
{
    public interface IGameConfigurationService
    {
        IGameConfiguration PrepareGameConfiguration(
            GameConfigurationType type = GameConfigurationType.WithNewPlayers,
            IGameConfiguration existentConfiguration = null);
    }
}