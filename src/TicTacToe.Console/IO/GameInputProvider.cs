using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.IO
{
    public class GameInputProvider : IGameInputProvider
    {
        private readonly IConsole _console;
        private readonly IConsoleInputProvider _consoleInput;


        public GameInputProvider(IConsoleInputProvider consoleInput, IConsole console)
        {
            _console = console;
            _consoleInput = consoleInput;
        }


        public (int row, int column) GetPositionToMakeMove(IPlayer player)
        {
            _console.WriteLine($"{player.FirstName} {player.LastName}, please, choose where to put figure:");
            var row = _consoleInput.GetInt("Row:") - 1;
            var column = _consoleInput.GetInt("Column:") - 1;

            return (row, column);
        }
    }
}