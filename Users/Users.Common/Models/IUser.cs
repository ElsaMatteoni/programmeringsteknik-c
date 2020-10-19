using System;

namespace Users.Common.Models
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Phone { get; set; }

        bool SubscribeToNewsletter { get; set; }
    }
}
