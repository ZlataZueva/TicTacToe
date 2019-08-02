using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class CircleDrawer : FigureDrawer
    {
        public CircleDrawer(IConsole console) 
            : base(FigureType.Circle, console)
        {

        }


        protected override void Draw(IFigure figure)
        {
            Console.Write(" o ");
        }
    }
}