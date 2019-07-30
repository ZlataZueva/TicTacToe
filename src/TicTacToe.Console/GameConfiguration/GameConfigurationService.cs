using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using Common.Extensions;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.GameConfiguration
{
    public class GameConfigurationService : IGameConfigurationService
    {
        private readonly IGameConfigurationFactory _gameConfigurationFactory;
        private readonly IPlayersRegistrationService _playersRegistrationService;
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _consoleInputProvider;


        public GameConfigurationService(
            IGameConfigurationFactory gameConfigurationFactory, 
            IPlayersRegistrationService playersRegistrationService, 
            IConsole console, 
            IConsoleInputProvider consoleInputProvider)
        {
            _gameConfigurationFactory = gameConfigurationFactory;
            _playersRegistrationService = playersRegistrationService;
            _console = console;
            _consoleInputProvider = consoleInputProvider;
        }


        public IGameConfiguration PrepareGameConfiguration(
            ConfigurationCreationMode mode = ConfigurationCreationMode.NewPlayers,
            IGameConfiguration existentConfiguration = null)
        {
            if (mode == ConfigurationCreationMode.ExistingPlayers && existentConfiguration == null)
            {
                throw new ArgumentNullException(nameof(existentConfiguration),
                    "Existent configuration should not be null to create configuration with existing players");
            }
            var players = mode == ConfigurationCreationMode.NewPlayers
                ? RegisterPlayers()
                : existentConfiguration.Players;
            var firstPlayerIndex = GetFirstPlayerIndex(players);
            var boardSize = GetBoardSize();

            return _gameConfigurationFactory.CreateGameConfiguration(players, firstPlayerIndex, boardSize);
        }


        private IReadOnlyCollection<IPlayer> RegisterPlayers()
        {
            var availableFigures = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToList();
            var playersNumber = GetPlayersNumber(availableFigures.Count);
            var players = new List<IPlayer>();
            for (var n = 0; n < playersNumber; n++)
            {
                var player = _playersRegistrationService.Register(availableFigures);
                players.Add(player);
                _console.WriteLine($"Registered player: {player.FirstName} {player.LastName} with figure - {player.FigureType}");
                availableFigures.Remove(player.FigureType);
            }

            return players;
        }

        private int GetPlayersNumber(int max)
        {
            int playersNumber;
            do
            {
                playersNumber = _consoleInputProvider.GetInt($"Please, enter the number of players (up to {max}):");
            } while (playersNumber <= 1 || playersNumber > max);

            return playersNumber;
        }

        private int GetFirstPlayerIndex(IReadOnlyCollection<IPlayer> players)
        {
            _console.WriteLine("Players:");
            players.ForEach((i, player) => _console.WriteLine($"{i + 1}. {player.FirstName} {player.LastName}"));
            int firstPlayerNumber;
            do
            {
                firstPlayerNumber = _consoleInputProvider.GetInt("Please, choose who starts the game (enter player's number):");
            } while (firstPlayerNumber <= 0 || firstPlayerNumber > players.Count);

            return firstPlayerNumber - 1;
        }

        private int GetBoardSize()
        {
            int boardSize;
            do
            {
                boardSize = _consoleInputProvider.GetInt("Please, enter the size of the board:");
            } while (boardSize <= 0);

            return boardSize;
        }
    }
}