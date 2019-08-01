using System;
using iTechArt.TicTacToe.Console.Drawers;
using iTechArt.TicTacToe.Console.GameConfiguration;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Console.IO;
using iTechArt.TicTacToe.Console.Players;
using iTechArt.TicTacToe.Foundation.Board;
using iTechArt.TicTacToe.Foundation.Cell;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Game;
using iTechArt.TicTacToe.Foundation.Game.GameResults;
using iTechArt.TicTacToe.Foundation.Game.StepResults;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.WinningStates;
using GameConsole = iTechArt.TicTacToe.Console.IO.Console;

namespace iTechArt.TicTacToe
{
    internal class Program
    {
        private static IConsole _console;
        private static IBoardDrawer _boardDrawer;


        public static void Main(string[] args)
        {
            _console = new GameConsole();
            var figureDrawerFactory = new FigureDrawerFactory(_console);
            var boardDrawerFactory = new BoardDrawerFactory(_console, figureDrawerFactory);
            _boardDrawer = boardDrawerFactory.CreateBoardDrawer();

            var consoleInputProvider = new ConsoleInputProvider(_console);
            var gameConfigurationFactory = new GameConfigurationFactory();
            var playerFactory = new PlayerFactory();
            var playerRegistrationService = new PlayerRegistrationService(playerFactory, _console, consoleInputProvider);
            var gameConfigurationService = new GameConfigurationService(
                gameConfigurationFactory, playerRegistrationService, _console, consoleInputProvider);
            var cellFactory = new CellFactory();
            var figureFactory = new FigureFactory();
            var boardFactory = new BoardFactory(cellFactory, figureFactory);
            var winningStatesFactory = new WinningStatesFactory();
            var gameInputProvider = new GameInputProvider(consoleInputProvider, _console);
            var gameFactory = new GameFactory(boardFactory, winningStatesFactory, gameInputProvider);

            var chosenOptionNumber = 2;
            IGameConfiguration gameConfiguration = null;
            while(chosenOptionNumber != 3)
            {
                gameConfiguration = chosenOptionNumber == 1
                    ? gameConfigurationService.CreateGameConfiguration(gameConfiguration)
                    : gameConfigurationService.CreateGameConfiguration();
                var game = gameFactory.CreateGame(gameConfiguration);
                game.StepCompleted += OnStepCompleted;
                game.GameFinished += OnGameFinished;
                game.Run();
                game.StepCompleted -= OnStepCompleted;
                game.GameFinished -= OnGameFinished;
                _console.WriteLine("1. Continue with the same players");
                _console.WriteLine("2. Register new players");
                _console.WriteLine("3. Exit");
                do
                {
                    chosenOptionNumber = consoleInputProvider.GetInt("Please, choose one of the options:");
                } while (chosenOptionNumber <= 0 || chosenOptionNumber > 3);
            }
        }


        private static void OnStepCompleted(object sender, StepCompletedEventArgs e)
        {
            var stepResult = e.Result;
            switch (stepResult.Type)
            {
                case StepResultType.Success:
                    var successfulResult = (SuccessfulStepResult)stepResult;
                    _boardDrawer.DrawBoard(successfulResult.Board);
                    break;
                case StepResultType.NonexistentCell:
                    _console.WriteLine("Specified position doesn't exist");
                    break;
                case StepResultType.OccupiedCell:
                    var occupiedCellResult = (OccupiedCellStepResult) stepResult;
                    _console.WriteLine(
                        $"Specified position is occupied by {occupiedCellResult.Cell.Figure.Type}");
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
                    var winningResult = (WinningGameResult) gameResult;
                    _console.WriteLine($"{winningResult.Winner.FirstName} {winningResult.Winner.LastName} is the winner!");
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
