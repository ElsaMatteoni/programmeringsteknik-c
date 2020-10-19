using Users.Common.Models;

namespace Users.Common.Services
{
    public interface IPasswordService
    {
        /// <summary>
        /// Generates a password with specified parameters
        /// </summary>
        /// <param name="length">Length of the password in characters</param>
        /// <param name="capitalLetters">Amount of capital letters</param>
        /// <param name="numbers">Amount of numbers</param>
        /// <param name="specialChars">Amount of special characters</param>
        /// <returns>A resulting password as string</returns>
        string GeneratePassword(uint length, uint capitalLetters = 1, uint numbers = 1, uint specialChars = 1);

        /// <summary>
        /// Validates a password by specified parameters
        /// </summary>
        /// <param name="length">Length of the password in characters</param>
        /// <param name="capitalLetters">Amount of capital letters</param>
        /// <param name="numbers">Amount of numbers</param>
        /// <param name="specialChars">Amount of special characters</param>
        /// <returns>A response indicating success or failure.</returns>
        IServiceResponse ValidatePassword(uint length, uint capitalLetters = 1, uint numbers = 1, uint specialChars = 1);
    }
}
