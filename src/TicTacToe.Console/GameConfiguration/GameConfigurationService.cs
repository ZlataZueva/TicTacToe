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
        private readonly IGameConfigurationFactory _configurationFactory;
        private readonly IPlayersRegistrationService _registrationService;
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _consoleInput;

        private IList<IPlayer> _players;


        public GameConfigurationService(
            IGameConfigurationFactory configurationFactory, 
            IPlayersRegistrationService registrationService, 
            IConsole console, 
            IConsoleInputProvider consoleInput)
        {
            _configurationFactory = configurationFactory;
            _registrationService = registrationService;
            _console = console;
            _consoleInput = consoleInput;
        }


        public IGameConfiguration GetGameConfiguration(GameConfigurationType type = GameConfigurationType.WithNewPlayers)
        {
            if (type == GameConfigurationType.WithNewPlayers || !_players.Any())
            {
                _players = new List<IPlayer>();
                var availableFigures = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToList();
                int playersNumber;
                do
                {
                    playersNumber = _consoleInput.GetInt($"Please, enter the number of players (up to {availableFigures.Count}):");
                } while (playersNumber <= 1 || playersNumber > availableFigures.Count);
                for (var i = 0; i < playersNumber; i++)
                {
                    var player = _registrationService.Register(availableFigures);
                    _players.Add(player);
                    availableFigures.Remove(player.FigureType);
                }
            }
            _console.WriteLine("Players:");
            _players.ForEach(player => _console.WriteLine($"{_players.IndexOf(player) + 1}. {player.FirstName} {player.LastName}"));
            int firstPlayerNumber;
            do
            {
                firstPlayerNumber = _consoleInput.GetInt("Please, choose who starts the game (enter player's number):");
            } while (firstPlayerNumber <= 0 || firstPlayerNumber > _players.Count);
            int boardSize;
            do
            {
                boardSize = _consoleInput.GetInt("Please, enter the size of the board:");
            } while (boardSize <= 0);

            return _configurationFactory.CreateGameConfiguration(_players.ToList(), firstPlayerNumber - 1, boardSize);
        }
    }
}