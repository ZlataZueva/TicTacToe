using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.Input
{
    public class Console : IConsole
    {
        public void WriteLine(string s)
        {
            System.Console.WriteLine(s);
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}