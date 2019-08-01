using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IFigureDrawerFactory
    {
        IFigureDrawer CreateFigureDrawer(FigureType figureType);
    }
}