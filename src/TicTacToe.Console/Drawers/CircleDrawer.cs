using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class CircleDrawer : FigureDrawer
    {
        public CircleDrawer(IConsole console) 
            : base(FigureType.Circle, console)
        {

        }


        public override void DrawFigure()
        {
            Console.Write(" o ");
        }
    }
}