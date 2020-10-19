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
            var passwordLength = uint.Parse(characterInput);

            Console.Write("How many uppercase letters? ");
            var uppercaseInput = Console.ReadLine();
            var uppercaseCount = uint.Parse(uppercaseInput);

            Console.Write("How many numbers? ");
            var numbersInput = Console.ReadLine();
            var numberCount = uint.Parse(numbersInput);

            Console.Write("How many special characters? ");
            var specialInput = Console.ReadLine();
            var specialCount = uint.Parse(specialInput);

            var passwordGenerator = new PasswordService();
            var password = passwordGenerator.GeneratePassword(passwordLength, uppercaseCount, numberCount, specialCount);


            Console.WriteLine($"Your password is: {password}");
        }
    }
}
