using iTechArt.TicTacToe.Foundation.Board;
using iTechArt.TicTacToe.Foundation.Cell;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Game;
using iTechArt.TicTacToe.Foundation.WinningStates;
using TicTacToe.Console.GameConfiguration;
using TicTacToe.Console.Interfaces;
using TicTacToe.Console.IO;
using TicTacToe.Console.Players;
using Console = TicTacToe.Console.IO.Console;

namespace iTechArt.TicTacToe
{
    class Program
    {
        private static IGameOutputProvider _gameOutputProvider;

        static void Main(string[] args)
        {
            var console = new Console();
            var consoleInputProvider = new ConsoleInputProvider(console);
            var configurationService = new GameConfigurationService(
                new GameConfigurationFactory(),
                new PlayerRegistrationService(new PlayerFactory(), console, consoleInputProvider),
                console,
                consoleInputProvider);
            var gameFactory = new GameFactory(
                new BoardFactory(new CellFactory(), new FigureFactory()),
                new WinningStatesFactory(), 
                new GameInputProvider(consoleInputProvider, console));
            _gameOutputProvider = new GameOutputProvider(console);

            var configuration = configurationService.CreateGameConfiguration();
            var game = gameFactory.CreateGame(configuration);
            game.StepCompleted += OnStepCompleted;
            game.GameFinished += OnGameFinished;
            game.Run();
        }


        private static void OnStepCompleted(object sender, StepCompletedEventArgs e)
        {
            _gameOutputProvider.ShowStepResult(e.Result);
        }

        private static void OnGameFinished(object sender, GameFinishedEventArgs e)
        {
            _gameOutputProvider.ShowGameResult(e.Result);
        }
    }
}