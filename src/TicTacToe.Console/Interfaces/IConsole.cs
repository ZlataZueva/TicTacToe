namespace TicTacToe.Console.Interfaces
{
    public interface IConsole
    {
        void WriteLine(string s = "");

        string ReadLine();
    }
}