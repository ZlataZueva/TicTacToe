using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.IO
{
    public class Console : IConsole
    {
        public void Write(string s)
        {
            System.Console.Write(s);
        }

        public void WriteLine(string s = "")
        {
            System.Console.WriteLine(s);
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}