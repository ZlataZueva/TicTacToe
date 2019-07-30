using iTechArt.TicTacToe.Foundation.Board;
using iTechArt.TicTacToe.Foundation.Cell;
using iTechArt.TicTacToe.Foundation.Figures;
using TicTacToe.Console.IO;
using Console = TicTacToe.Console.IO.Console;

namespace iTechArt.TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(3, new CellFactory(), new FigureFactory());
            var gameOutput = new GameOutputProvider(new Console());
            gameOutput.ShowBoard(board);
            board.PlaceFigure(1, 1, FigureType.Circle);
            gameOutput.ShowBoard(board);
            board.PlaceFigure(1, 2, FigureType.Cross);
            gameOutput.ShowBoard(board);
            board.PlaceFigure(2, 2, FigureType.Circle);
            gameOutput.ShowBoard(board);
            board.PlaceFigure(3, 1, FigureType.Cross);
            gameOutput.ShowBoard(board);
            System.Console.ReadLine();
        }
    }
}