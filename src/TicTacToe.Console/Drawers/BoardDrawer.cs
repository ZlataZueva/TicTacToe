using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class BoardDrawer : IBoardDrawer
    {
        private readonly IConsole _console;


        public BoardDrawer(IConsole console)
        {
            _console = console;
        }


        public void DrawBoard(IBoard board)
        {
            DrawBorder(-1, board.Size);
            foreach (var row in Enumerable.Range(0, board.Size))
            {
                DrawRow(board.Where(c => c.Row == row));
                DrawBorder(row, board.Size);
            }
        }


        private void DrawRow(IEnumerable<ICell> row)
        {
            _console.Write("│");
            foreach (var cell in row)
            {
                if (cell.IsEmpty)
                {
                    _console.Write("   ");
                }
                else
                {
                    switch (cell.Figure.Type)
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
                _console.Write("│");
            }
            _console.WriteLine();
        }

        private void DrawBorder(int row, int boardSize)
        {
            if (row == -1)
            {
                _console.WriteLine("┌" + String.Concat(Enumerable.Repeat("───┬", boardSize - 1)) + "───┐");
            }
            if (row >= 0 && row < boardSize - 1)
            {
                _console.WriteLine("├" + String.Concat(Enumerable.Repeat("───┼", boardSize - 1)) + "───┤");
            }
            if (row == boardSize - 1)
            {
                _console.WriteLine("└" + String.Concat(Enumerable.Repeat("───┴", boardSize - 1)) + "───┘");
            }
        }
    }
}