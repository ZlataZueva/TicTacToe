namespace TicTacToe.Console.Interfaces
{
    public interface IConsole
    {
        void Write(string s);

        void WriteLine(string s);

        string ReadLine();
    }
}