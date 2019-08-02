using System.Collections.Generic;
using iTechArt.TicTacToe.Console.Interfaces;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Console.Drawers
{
    public class FigureDrawerProvider : IFigureDrawerProvider
    {
        private readonly IFigureDrawerFactory _figureDrawerFactory;
        private readonly IDictionary<FigureType, IFigureDrawer> _figureDrawersDictionary;


        public FigureDrawerProvider(IFigureDrawerFactory figureDrawerFactory)
        {
            _figureDrawerFactory = figureDrawerFactory;
            _figureDrawersDictionary = new Dictionary<FigureType, IFigureDrawer>();
        }


        public IFigureDrawer GetFigureDrawer(FigureType figureType)
        {
            if (_figureDrawersDictionary.TryGetValue(figureType, out var figureDrawer))
            {
                return figureDrawer;
            }
            _figureDrawersDictionary.Add(figureType, _figureDrawerFactory.CreateFigureDrawer(figureType));

            return _figureDrawersDictionary[figureType];
        }
    }
}