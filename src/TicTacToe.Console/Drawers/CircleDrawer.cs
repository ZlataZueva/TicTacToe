using System;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class CircleDrawer : FigureDrawer
    {
        public CircleDrawer(IConsole console) 
            : base(console)
        {

        }


        public override void DrawFigure(IFigure figure)
        {
            if (figure.Type != FigureType.Circle)
            {
                throw new ArgumentException("Figure type should be Circle");
            }
            Console.Write(" o ");
        }
    }
}