using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.Extensions;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.Players
{
    public class PlayerRegistrationService : IPlayersRegistrationService
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _consoleInput;

        private readonly IList<FigureType> _availableFigureTypes;


        public PlayerRegistrationService(IPlayerFactory playerFactory, IConsole console, IConsoleInputProvider consoleInput)
        {
            _playerFactory = playerFactory;
            _console = console;
            _consoleInput = consoleInput;

            _availableFigureTypes = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToList();
        }


        public IPlayer Register()
        {
            var firstName = _consoleInput.GetString("Please, enter player's first name:");
            var lastName = _consoleInput.GetString("Please, enter player's last name:");
            var figureType = ChooseFigure();
            var player = _playerFactory.CreatePlayer(firstName, lastName, figureType);
            _availableFigureTypes.Remove(figureType);
            _console.WriteLine($"Registered player: {firstName} {lastName} with figure - {figureType}.");

            return player;
        }


        private FigureType ChooseFigure()
        {
            if (!_availableFigureTypes.Any())
            {
                throw new ArgumentException("No more figures left");
            }
            int chosenFigureNumber;
            if (_availableFigureTypes.Count == 1)
            {
                chosenFigureNumber = 1;
            }
            else
            {
                _console.WriteLine("Available figures:");
                _availableFigureTypes.ForEach(figure => _console.WriteLine($"{_availableFigureTypes.IndexOf(figure)+1}. {figure}"));
                do
                {
                    chosenFigureNumber = _consoleInput.GetInt("Please, enter figure's number:");
                } while (chosenFigureNumber <= 0 || chosenFigureNumber > _availableFigureTypes.Count);
            }

            return _availableFigureTypes[chosenFigureNumber - 1];
        }
    }
}