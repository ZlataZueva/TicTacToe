using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class CrossDrawer : FigureDrawer
    {
        public CrossDrawer(IConsole console) 
            : base(FigureType.Cross, console)
        {

        }


        protected override void Draw(IFigure figure)
        {
            Console.Write(" x ");
        }
    }
}