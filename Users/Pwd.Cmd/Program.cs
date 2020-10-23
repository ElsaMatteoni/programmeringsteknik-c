using System;
using Users.Common.Services;

namespace Pwd.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv ett program som genererar ett lösenord baserat på följande parametrar:
            // 1. Längd (positivt heltal)
            // 2. Antal stora bokstäver.
            // 3. Antal siffror.
            // 4. Antal specialtecken.

            Console.WriteLine("Password Generator");
            Console.WriteLine("___________________\n");
            Console.Write("How many characters do you want your password to be? ");
            var characterInput = Console.ReadLine();
            uint passwordLength = 8;

            Console.Write("How many uppercase letters? ");
            var uppercaseInput = Console.ReadLine();
            uint uppercaseCount = 2;

            Console.Write("How many numbers? ");
            var numbersInput = Console.ReadLine();
            uint numberCount = 2;

            Console.Write("How many special characters? ");
            var specialInput = Console.ReadLine();
            uint specialCount = 1;

            var passwordGenerator = new PasswordService();
            var password = passwordGenerator.GeneratePassword(passwordLength, uppercaseCount, numberCount, specialCount);


            Console.WriteLine($"Your password is: {password}");
        }
    }
}
