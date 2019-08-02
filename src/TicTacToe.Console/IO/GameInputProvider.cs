using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.IO
{
    public class GameInputProvider : IGameInputProvider
    {
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _consoleInputProvider;


        public GameInputProvider(IConsoleInputProvider consoleInputProvider, IConsole console)
        {
            _console = console;
            _consoleInputProvider = consoleInputProvider;
        }


        public (int row, int column) GetPositionToMakeMove(IPlayer player)
        {
            _console.WriteLine($"{player.FirstName} {player.LastName}, please, choose where to put figure:");
            var row = _consoleInputProvider.GetInt("Row:") - 1;
            var column = _consoleInputProvider.GetInt("Column:") - 1;

            return (row, column);
        }
    }
}