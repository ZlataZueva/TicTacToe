using System;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class CrossDrawer : FigureDrawer
    {
        public CrossDrawer(IConsole console) 
            : base(console)
        {

        }


        public override void DrawFigure(IFigure figure)
        {
            if (figure.Type != FigureType.Cross)
            {
                throw new ArgumentException("Figure type should be Cross");
            }
            Console.Write(" x ");
        }
    }
}