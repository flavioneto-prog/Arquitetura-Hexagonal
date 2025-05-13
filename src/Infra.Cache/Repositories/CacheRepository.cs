using System.Text;
using Domain.Ports;
using Microsoft.Extensions.Caching.Distributed;

namespace Infra.Cache.Repositories
{
    public class CacheRepository(IDistributedCache distributedCache) : ICacheRepository
    {
        public async Task AddAsync(string key, string value, int expirationInSeconds, CancellationToken cancellationToken)
        {
            var options = new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(expirationInSeconds) };
            var bytes = Encoding.ASCII.GetBytes(value);
            await distributedCache.SetAsync(key, bytes, options, cancellationToken);
        }

        public async Task<byte[]?> GetAsync(string key, CancellationToken cancellationToken)
        {
            return await distributedCache.GetAsync(key, cancellationToken);
        }
    }
}
