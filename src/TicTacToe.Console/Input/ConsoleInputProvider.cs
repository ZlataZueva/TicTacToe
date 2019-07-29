using System;
using TicTacToe.Console.Interfaces;

namespace TicTacToe.Console.Input
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
                var input = _console.ReadLine();
                parseResult = Int32.TryParse(input, out number);
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