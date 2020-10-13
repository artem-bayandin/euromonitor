using System;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Guid? UserId { get; }
        string Email { get; }
        bool IsAuthenticated { get; }
    }
}
