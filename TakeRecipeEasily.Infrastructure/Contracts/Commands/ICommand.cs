﻿using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands
{
    public interface ICommand
    {
        Guid UserId { get; set; }
    }
}
