using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IFigureDrawerProvider
    {
        IFigureDrawer GetFigureDrawer(FigureType figureType);
    }
}