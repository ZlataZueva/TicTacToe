using System;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public abstract class FigureDrawer : IFigureDrawer
    {
        private readonly FigureType _figureType;


        protected IConsole Console { get; }


        protected FigureDrawer(FigureType figureType, IConsole console)
        {
            _figureType = figureType;

            Console = console;
        }


        public void DrawFigure(IFigure figure)
        {
            if (figure.Type != _figureType)
            {
                throw new ArgumentException($"Figure type should be {_figureType}");
            }
            Draw(figure);
        }


        protected abstract void Draw(IFigure figure);
    }
}