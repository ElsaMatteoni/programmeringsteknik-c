using System;

namespace WhichHolidayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implementera följande flödesschema med metoder och användarinmatning
            // https://pbs.twimg.com/media/EQup9bwXUAEK5a_?format=jpg&name=large

            int value;

            while (GetInput(out value) == false);

            Console.WriteLine($"Finally we got a value {value}");
        }

        static bool GetInput(out int inputValue)
        {
            Console.Write("Enter a number: ");
            try
            {
                string rawInput = Console.ReadLine();
                inputValue = int.Parse(rawInput);

                EnsureValidValue(inputValue);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                inputValue = -1;

                return false;
            }
        }

        static void EnsureValidValue(int value)
        {
            if (value > 1_000_000)
                throw new ArgumentOutOfRangeException("Value cannot be above 1 000 000");
        }
    }
}
