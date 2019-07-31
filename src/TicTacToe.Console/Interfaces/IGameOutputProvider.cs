using iTechArt.TicTacToe.Foundation.Game.GameResults;
using iTechArt.TicTacToe.Foundation.Game.StepResults;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Console.Interfaces
{
    public interface IGameOutputProvider
    {
        void ShowBoard(IBoard board);

        void ShowStepResult(StepResult stepResult);

        void ShowGameResult(GameResult gameResult);
    }
}