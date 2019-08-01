using iTechArt.TicTacToe.Console.Drawers;
using iTechArt.TicTacToe.Foundation.Board;
using iTechArt.TicTacToe.Foundation.Cell;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(3, new CellFactory(), new FigureFactory());
            var boardDrawer = new BoardDrawer(new Console.IO.Console());
            boardDrawer.DrawBoard(board);
            board.PlaceFigure(1, 1, FigureType.Circle);
            boardDrawer.DrawBoard(board);
            board.PlaceFigure(1, 2, FigureType.Cross);
            boardDrawer.DrawBoard(board);
            board.PlaceFigure(2, 2, FigureType.Circle);
            boardDrawer.DrawBoard(board);
            board.PlaceFigure(3, 1, FigureType.Cross);
            boardDrawer.DrawBoard(board);
            System.Console.ReadLine();
        }
    }
}