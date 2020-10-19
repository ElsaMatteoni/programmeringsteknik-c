using System;
using Users.Common.Models;

namespace Users.Common.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Gets a user by email
        /// </summary>
        /// <param name="email">User email (has to be unique)</param>
        /// <returns>The user object</returns>
        /// <exception cref="ArgumentOutOfRangeException">If user isn't found</exception>
        IUser Get(string email);

        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="userId">The users internal id</param>
        /// <returns>The user object</returns>
        /// <exception cref="ArgumentOutOfRangeException">If user isn't found</exception>
        IUser Get(Guid userId);

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">The user to register</param>
        /// <returns>A response indicating success if the user was registered, exception and message if registration failed.</returns>
        IServiceResponse Register(IUser user);

        /// <summary>
        /// Sets the password for a user.
        /// </summary>
        /// <param name="userId">The users internal id</param>
        /// <param name="password">The password to set</param>
        /// <returns>A response indicating success if the password was set, exception and message if operation failed.</returns>
        IServiceResponse SetPassword(Guid userId, string password);

        /// <summary>
        /// Authenticates and logs a user in, normally this method returns a token or sets a cookie.
        /// </summary>
        /// <param name="email">User email (has to be unique)</param>
        /// <param name="password">User password</param>
        /// <returns>A response indicating success if the user was registered, exception and message if login failed.</returns>
        IServiceResponse Login(string email, string password);
    }
}
