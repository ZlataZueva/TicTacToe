using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public abstract class FigureDrawer : IFigureDrawer
    {
        protected IConsole Console;


        protected FigureDrawer(IConsole console)
        {
            Console = console;
        }


        public abstract void DrawFigure(IFigure figure);
    }
}