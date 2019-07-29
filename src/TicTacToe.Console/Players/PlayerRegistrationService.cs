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


        public PlayerRegistrationService(IPlayerFactory playerFactory, IConsole console, IConsoleInputProvider consoleInput)
        {
            _playerFactory = playerFactory;
            _console = console;
            _consoleInput = consoleInput;
        }


        public IPlayer Register(IList<FigureType> availableFigureTypes)
        {
            var firstName = _consoleInput.GetString("Please, enter player's first name:");
            var lastName = _consoleInput.GetString("Please, enter player's last name:");
            var figureType = ChooseFigure(availableFigureTypes);
            var player = _playerFactory.CreatePlayer(firstName, lastName, figureType);
            _console.WriteLine($"Registered player: {firstName} {lastName} with figure - {figureType}.");

            return player;
        }


        private FigureType ChooseFigure(IList<FigureType> availableFigureTypes)
        {
            if (!availableFigureTypes.Any())
            {
                throw new ArgumentException("No more figures left");
            }
            int chosenFigureNumber;
            if (availableFigureTypes.Count == 1)
            {
                chosenFigureNumber = 1;
            }
            else
            {
                _console.WriteLine("Available figures:");
                availableFigureTypes.ForEach(figure => _console.WriteLine($"{availableFigureTypes.IndexOf(figure) + 1}. {figure}"));
                do
                {
                    chosenFigureNumber = _consoleInput.GetInt("Please, enter figure's number:");
                } while (chosenFigureNumber <= 0 || chosenFigureNumber > availableFigureTypes.Count);
            }

            return availableFigureTypes[chosenFigureNumber - 1];
        }
    }
}