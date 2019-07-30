using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.Extensions;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.GameConfiguration
{
    public class GameConfigurationService : IGameConfigurationService
    {
        private readonly IGameConfigurationFactory _gameConfigurationFactory;
        private readonly IPlayersRegistrationService _playersRegistrationService;
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _consoleInputProvider;

        private ICollection<IPlayer> _players;


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


        public IGameConfiguration PrepareGameConfiguration(GameConfigurationType type = GameConfigurationType.WithNewPlayers)
        {
            if (type == GameConfigurationType.WithNewPlayers || !_players.Any())
            {
                _players = new List<IPlayer>();
                var availableFigures = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToList();
                var playersNumber = GetPlayersNumber(availableFigures.Count);
                _players = RegisterPlayers(playersNumber, availableFigures);
            }
            var firstPlayerIndex = GetFirstPlayerIndex(_players);
            var boardSize = GetBoardSize();

            return _gameConfigurationFactory.CreateGameConfiguration(_players.ToList(), firstPlayerIndex - 1, boardSize);
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

        private ICollection<IPlayer> RegisterPlayers(int count, ICollection<FigureType> availableFigures)
        {
            var players = new List<IPlayer>();
            for (var n = 0; n < count; n++)
            {
                var player = _playersRegistrationService.Register(availableFigures.ToList());
                players.Add(player);
                _console.WriteLine($"Registered player: {player.FirstName} {player.LastName} with figure - {player.FigureType}");
                availableFigures.Remove(player.FigureType);
            }

            return players;
        }

        private int GetFirstPlayerIndex(ICollection<IPlayer> players)
        {
            _console.WriteLine("Players:");
            players.ForEach((i, player) => _console.WriteLine($"{i + 1}. {player.FirstName} {player.LastName}"));
            int firstPlayerNumber;
            do
            {
                firstPlayerNumber = _consoleInputProvider.GetInt("Please, choose who starts the game (enter player's number):");
            } while (firstPlayerNumber <= 0 || firstPlayerNumber > _players.Count);

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