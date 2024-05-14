﻿using Expert.Domain.Entities;

namespace Expert.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}