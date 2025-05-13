using Domain.Ports;

namespace Application.Services
{
    public class CacheServiceManager(ICacheRepository cacheRepository) : ICacheService
    {
        public async Task AddNewAsync(string key, string value, int expirationInSeconds, CancellationToken cancellationToken)
        {
            await cacheRepository.AddAsync(key, value, expirationInSeconds, cancellationToken);
        }

        public async Task<byte[]?> GetByKeyAsync(string key, CancellationToken cancellationToken)
        {
            return await cacheRepository.GetAsync(key, cancellationToken);
        }
    }
}
