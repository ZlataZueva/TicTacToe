using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.Players
{
    public class PlayerRegistrationService : IPlayersRegistrationService
    {
        private readonly IPlayerFactory _playerFactory;

        private readonly IList<FigureType> _availableFigureTypes;


        public PlayerRegistrationService(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;

            _availableFigureTypes = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToList();
        }


        public IPlayer Register()
        {
            ShowMessage("Please, enter player's first name:");
            var firstName = GetName();
            ShowMessage("Please, enter player's last name:");
            var lastName = GetName();
            var figureType = ChooseFigure();
            var player = _playerFactory.CreatePlayer(firstName, lastName, figureType);
            _availableFigureTypes.Remove(figureType);
            ShowMessage($"Registered player: {firstName} {lastName} with figure - {figureType}.");

            return player;
        }


        private FigureType ChooseFigure()
        {
            if (_availableFigureTypes.Count == 0)
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
                do
                {
                    ShowMessage("Please, choose one of the figures:");
                    var counter = 1;
                    foreach (var figure in _availableFigureTypes)
                    {
                        ShowMessage($"{counter++}. {figure}");
                    }
                    ShowMessage("Enter figure's number:");
                } while (!(int.TryParse(GetInput(), out chosenFigureNumber) &&
                           chosenFigureNumber > 0 && chosenFigureNumber <= _availableFigureTypes.Count));
            }

            return _availableFigureTypes[chosenFigureNumber - 1];
        }

        private static string GetName()
        {
            string name;
            do
            {
                name = GetInput();
                if (name == string.Empty)
                {
                    ShowMessage("Name should not be empty");
                }
            } while (String.IsNullOrEmpty(name));

            return name;
        }

        private static void ShowMessage(string message)
        {
            System.Console.WriteLine(message);
        }

        private static string GetInput()
        {
            return System.Console.ReadLine();
        }
    }
}