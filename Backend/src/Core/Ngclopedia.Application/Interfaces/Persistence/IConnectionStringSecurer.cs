﻿namespace Ngclopedia.Application.Interfaces.Persistence;

public interface IConnectionStringSecurer
{
    string? MakeSecure(string? connectionString, string? dbProvider = null);
}