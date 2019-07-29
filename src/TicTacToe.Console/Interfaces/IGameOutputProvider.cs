using iTechArt.TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Console.Interfaces
{
    public interface IGameOutputProvider
    {
        void ShowBoard(IBoard board);
    }
}