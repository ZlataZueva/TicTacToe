using System;
using iTechArt.TicTacToe.Foundation.Figures;
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
                    if (column != board.Size - 1)
                    {
                        _console.Write("│");
                    }
                }
                _console.WriteLine();
                if (row != board.Size - 1)
                {
                    for (var column = 0; column < board.Size; column++)
                    {
                        _console.Write("───");
                        if (column != board.Size - 1)
                        {
                            _console.Write("┼");
                        }
                    }
                    _console.WriteLine();
                }
            }
            _console.WriteLine();
        }
    }
}