using System;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Game.GameResults;
using iTechArt.TicTacToe.Foundation.Game.StepResults;
using iTechArt.TicTacToe.Foundation.Interfaces;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.IO
{
    public class GameOutputProvider : IGameOutputProvider
    {
        private readonly IConsole _console;


        public GameOutputProvider(IConsole console)
        {
            _console = console;
        }


        public void ShowBoard(IBoard board)
        {
            _console.WriteLine();
            for (var row = 0; row < board.Size; row++)
            {
                for (var column = 0; column < board.Size; column++)
                {
                    if (board[row, column].IsEmpty)
                    {
                        _console.Write("   ");
                    }
                    else
                    {
                        switch (board[row, column].Figure.Type)
                        {
                            case FigureType.Cross:
                                _console.Write(" x ");
                                break;
                            case FigureType.Circle:
                                _console.Write(" o ");
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    _console.Write(column != board.Size - 1? "│" : "");
                }
                _console.WriteLine();
                if (row != board.Size - 1)
                {
                    _console.WriteLine(String.Concat(Enumerable.Repeat("───┼", board.Size - 1)) + "───");
                }
            }
            _console.WriteLine();
        }

        public void ShowStepResult(StepResult stepResult)
        {
            switch (stepResult.Type)
            {
                case StepResultType.Success:
                    //_console.WriteLine("Step completed successfully");
                    ShowBoard(((SuccessfulStepResult) stepResult).Board);
                    break;
                case StepResultType.NonexistentCell:
                    _console.WriteLine("Specified position doesn't exist");
                    break;
                case StepResultType.OccupiedCell:
                    var cell = ((OccupiedCellStepResult) stepResult).Cell;
                    var occupier = cell.IsEmpty? "nobody" : $"{cell.Figure.Type}";
                    _console.WriteLine(
                        $"Specified position is occupied by {occupier}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stepResult.Type), stepResult.Type, "Unknown step result");
            }
        }

        public void ShowGameResult(GameResult gameResult)
        {
            switch (gameResult.Type)
            {
                case GameResultType.Win:
                    var winner = ((WinningGameResult) gameResult).Winner;
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