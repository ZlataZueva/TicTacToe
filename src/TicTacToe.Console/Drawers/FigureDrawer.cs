using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public abstract class FigureDrawer : IFigureDrawer
    {
        protected IConsole Console;


        public FigureType FigureType { get; }


        protected FigureDrawer(FigureType figureType, IConsole console)
        {
            Console = console;
            FigureType = figureType;
        }


        public abstract void DrawFigure();
    }
}