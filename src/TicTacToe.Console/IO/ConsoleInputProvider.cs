using System;
using iTechArt.TicTacToe.Console.Interfaces;

namespace iTechArt.TicTacToe.Console.IO
{
    public class ConsoleInputProvider : IConsoleInputProvider
    {
        private readonly IConsole _console;


        public ConsoleInputProvider(IConsole console)
        {
            _console = console;
        }


        public string GetString(string message = "")
        {
            ShowMessage(message);
            string input;
            do
            {
                input = _console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    _console.WriteLine("String should not be empty");
                }
            } while (String.IsNullOrEmpty(input));

            return input;
        }

        public int GetInt(string message = "")
        {
            ShowMessage(message);
            int number;
            bool parseResult;
            do
            {
                parseResult = Int32.TryParse(_console.ReadLine(), out number);
                if (!parseResult)
                {
                    _console.WriteLine("Please, enter a number");
                }
            } while (!parseResult);

            return number;
        }


        private void ShowMessage(string msg)
        {
            if (!String.IsNullOrEmpty(msg))
            {
                _console.WriteLine(msg);
            }
        }
    }
}