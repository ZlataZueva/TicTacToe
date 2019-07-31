﻿using System;
using System.Linq;
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
    }
}