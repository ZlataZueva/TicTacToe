using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.Common.Extensions;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.Players
{
    public class PlayerRegistrationService : IPlayersRegistrationService
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _consoleInputProvider;


        public PlayerRegistrationService(
            IPlayerFactory playerFactory, 
            IConsole console, 
            IConsoleInputProvider consoleInputProvider)
        {
            _playerFactory = playerFactory;
            _console = console;
            _consoleInputProvider = consoleInputProvider;
        }


        public IPlayer Register(IReadOnlyList<FigureType> availableFigureTypes)
        {
            var firstName = _consoleInputProvider.GetString("Please, enter player's first name:");
            var lastName = _consoleInputProvider.GetString("Please, enter player's last name:");
            var figureType = ChooseFigure(availableFigureTypes);

            return _playerFactory.CreatePlayer(firstName, lastName, figureType);
        }


        private FigureType ChooseFigure(IReadOnlyList<FigureType> availableFigureTypes)
        {
            if (!availableFigureTypes.Any())
            {
                throw new ArgumentException("No more figures left");
            }
            if (availableFigureTypes.Count == 1)
            {
                return availableFigureTypes.Single();
            }
            int chosenFigureNumber;
            _console.WriteLine("Available figures:");
            availableFigureTypes.ForEach((i, figure) => _console.WriteLine($"{i + 1}. {figure}"));
            do
            {
                chosenFigureNumber = _consoleInputProvider.GetInt("Please, enter figure's number:");
            } while (chosenFigureNumber <= 0 || chosenFigureNumber > availableFigureTypes.Count);

            return availableFigureTypes[chosenFigureNumber - 1];
        }
    }
}