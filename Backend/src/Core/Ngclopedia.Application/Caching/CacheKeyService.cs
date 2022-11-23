using Ngclopedia.Application.Interfaces.Common;

namespace Ngclopedia.Application.Caching;

public interface ICacheKeyService : IScopedService
{
    public string GetCacheKey(string name, object id, bool includeCurrentUserId = true);
}