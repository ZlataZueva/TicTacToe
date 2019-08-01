using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class CrossDrawer : FigureDrawer
    {
        public CrossDrawer(IConsole console) 
            : base(FigureType.Cross, console)
        {

        }


        public override void DrawFigure()
        {
            Console.Write(" x ");
        }
    }
}