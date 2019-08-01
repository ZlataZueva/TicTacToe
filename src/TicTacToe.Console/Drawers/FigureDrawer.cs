using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public abstract class FigureDrawer : IFigureDrawer
    {
        protected IConsole Console;


        public FigureType Type { get; }


        protected FigureDrawer(FigureType type, IConsole console)
        {
            Console = console;
            Type = type;
        }


        public abstract void DrawFigure();
    }
}