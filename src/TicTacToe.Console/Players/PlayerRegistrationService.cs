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
            ShowMessage($"Registered player: {firstName} {lastName} with figure - {figureType}.");

            return player;
        }


        private FigureType ChooseFigure()
        {
            if (_availableFigureTypes.Count == 0)
            {
                throw new ArgumentException("No more figures left");
            }
            int figureNumber;
            if (_availableFigureTypes.Count == 1)
            {
                figureNumber = 1;
            }
            else
            {
                do
                {
                    ShowMessage("Please, choose one of available figures:");
                    foreach (var figure in _availableFigureTypes)
                    {
                        ShowMessage($"{_availableFigureTypes.IndexOf(figure) + 1}. {figure}");
                    }
                    ShowMessage("Enter number of the figure:");
                } while (!(int.TryParse(GetInput(), out figureNumber) &&
                           figureNumber > 0 && figureNumber <= _availableFigureTypes.Count));
            }
            var figureType = _availableFigureTypes[figureNumber - 1];
            _availableFigureTypes.RemoveAt(figureNumber - 1);

            return figureType;
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
                if (name != null && name.ToCharArray().Any(char.IsDigit))
                {
                    ShowMessage("Name should not contain digits");
                }
            } while (string.IsNullOrEmpty(name) || name.ToCharArray().Any(char.IsDigit));

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