using System;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class FigureDrawerFactory : IFigureDrawerFactory
    {
        private readonly IConsole _console;


        public FigureDrawerFactory(IConsole console)
        {
            _console = console;
        }


        public IFigureDrawer CreateFigureDrawer(FigureType figureType)
        {
            switch (figureType)
            {
                case FigureType.Cross:
                    return new CrossDrawer(_console);
                case FigureType.Circle:
                    return new CircleDrawer(_console);
                default:
                    throw new ArgumentOutOfRangeException(nameof(figureType), figureType, "Unknown figure figureType");
            }
        }
    }
}