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
        private readonly IDictionary<FigureType, IFigureDrawer> _figureDrawersDictionary;


        public BoardDrawer(IConsole console, IFigureDrawerFactory figureDrawerFactory)
        {
            _console = console;
            _figureDrawersDictionary = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToDictionary(f => f, figureDrawerFactory.CreateFigureDrawer);
        }


        public void DrawBoard(IBoard board)
        {
            DrawRowBorder(-1, board.Size);
            foreach (var row in Enumerable.Range(0, board.Size))
            {
                DrawRow(board.Where(c => c.Row == row));
                DrawRowBorder(row, board.Size);
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
                    _figureDrawersDictionary[cell.Figure.Type].DrawFigure();
                }
                _console.Write("│");
            }
            _console.WriteLine();
        }

        private void DrawRowBorder(int row, int boardSize)
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