using System;
using iTechArt.TicTacToe.Foundation.Board;
using iTechArt.TicTacToe.Foundation.Cell;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Game;
using iTechArt.TicTacToe.Foundation.Game.GameResults;
using iTechArt.TicTacToe.Foundation.Game.StepResults;
using iTechArt.TicTacToe.Foundation.WinningStates;
using TicTacToe.Console.GameConfiguration;
using TicTacToe.Console.Interfaces;
using TicTacToe.Console.IO;
using TicTacToe.Console.Players;
using Console = TicTacToe.Console.IO.Console;

namespace iTechArt.TicTacToe
{
    internal class Program
    {
        private static IConsole _console;
        private static IBoardDrawer _boardDrawer;

        public static void Main(string[] args)
        {
            _console = new Console();
            _boardDrawer = new BoardDrawer(_console);

            var consoleInputProvider = new ConsoleInputProvider(_console);
            var configurationService = new GameConfigurationService(
                new GameConfigurationFactory(),
                new PlayerRegistrationService(new PlayerFactory(), _console, consoleInputProvider),
                _console,
                consoleInputProvider);
            var gameFactory = new GameFactory(
                new BoardFactory(new CellFactory(), new FigureFactory()),
                new WinningStatesFactory(), 
                new GameInputProvider(consoleInputProvider, _console));

            var configuration = configurationService.CreateGameConfiguration();
            var game = gameFactory.CreateGame(configuration);
            game.StepCompleted += OnStepCompleted;
            game.GameFinished += OnGameFinished;
            game.Run();
        }


        private static void OnStepCompleted(object sender, StepCompletedEventArgs e)
        {
            var stepResult = e.Result;
            switch (stepResult.Type)
            {
                case StepResultType.Success:
                    //_console.WriteLine("Step completed successfully");
                    _boardDrawer.ShowBoard(((SuccessfulStepResult)stepResult).Board);
                    break;
                case StepResultType.NonexistentCell:
                    _console.WriteLine("Specified position doesn't exist");
                    break;
                case StepResultType.OccupiedCell:
                    var cell = ((OccupiedCellStepResult)stepResult).Cell;
                    var occupier = cell.IsEmpty ? "nobody" : $"{cell.Figure.Type}";
                    _console.WriteLine(
                        $"Specified position is occupied by {occupier}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stepResult.Type), stepResult.Type, "Unknown step result");
            }
        }

        private static void OnGameFinished(object sender, GameFinishedEventArgs e)
        {
            var gameResult = e.Result;
            switch (gameResult.Type)
            {
                case GameResultType.Win:
                    var winner = ((WinningGameResult)gameResult).Winner;
                    _console.WriteLine($"{winner.FirstName} {winner.LastName} is the winner!");
                    break;
                case GameResultType.Draw:
                    _console.WriteLine("Friendship won :)");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameResult.Type), gameResult.Type, "Unknown game result");
            }
        }
    }
}
