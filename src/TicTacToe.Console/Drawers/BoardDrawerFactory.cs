using iTechArt.TicTacToe.Console.Interfaces;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class BoardDrawerFactory : IBoardDrawerFactory
    {
        private readonly IConsole _console;
        private readonly IFigureDrawerFactory _figureDrawerFactory;


        public BoardDrawerFactory(IConsole console, IFigureDrawerFactory figureDrawerFactory)
        {
            _console = console;
            _figureDrawerFactory = figureDrawerFactory;
        }


        public IBoardDrawer CreateBoardDrawer()
        {
            return new BoardDrawer(_console, _figureDrawerFactory);
        }
    }
}