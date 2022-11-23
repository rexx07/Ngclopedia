﻿using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Forums;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class ReactionRepository : RepositoryBase<Reaction>, IReactionRepository
{
    public ReactionRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Reaction>> GetAllReactionsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(r => r.CreatedOn)
            .ToListAsync();
    }

    public async Task<Reaction?> GetReactionAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateReaction(Reaction reaction)
    {
        Create(reaction);
    }

    public void DeleteReaction(Reaction reaction)
    {
        Delete(reaction);
    }
}