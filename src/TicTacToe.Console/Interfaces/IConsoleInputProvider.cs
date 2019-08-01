namespace iTechArt.TicTacToe.Console.Interfaces
{
    public interface IConsoleInputProvider
    {
        string GetString(string message = "");

        int GetInt(string message = "");
    }
}