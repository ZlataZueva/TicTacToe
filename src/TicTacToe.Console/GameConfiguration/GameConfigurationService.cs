using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.Common.Extensions;
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


        public IGameConfiguration CreateGameConfiguration(IGameConfiguration existingConfiguration = null)
        {
            var players = existingConfiguration?.Players ?? RegisterPlayers();
            var firstPlayerIndex = GetFirstPlayerIndex(players);
            var boardSize = GetBoardSize();

            return _gameConfigurationFactory.CreateGameConfiguration(players, firstPlayerIndex, boardSize);
        }


        private IReadOnlyCollection<IPlayer> RegisterPlayers()
        {
            var availableFigures = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToList();
            var numberOfPlayers = GetNumberOfPlayers(availableFigures.Count);
            var players = new List<IPlayer>();
            for (var i = 0; i < numberOfPlayers; i++)
            {
                _console.WriteLine($"Player {i + 1}:");
                var player = _playersRegistrationService.Register(availableFigures);
                players.Add(player);
                _console.WriteLine($"Registered player: {player.FirstName} {player.LastName} with figure - {player.FigureType}");
                availableFigures.Remove(player.FigureType);
            }

            return players;
        }

        private int GetNumberOfPlayers(int maxNumber)
        {
            int playersNumber;
            do
            {
                playersNumber = _consoleInputProvider.GetInt($"Please, enter the number of players (up to {maxNumber}):");
            } while (playersNumber <= 1 || playersNumber > maxNumber);

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