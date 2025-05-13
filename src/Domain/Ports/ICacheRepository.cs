namespace Domain.Ports
{
    public interface ICacheRepository
    {
        Task AddAsync(string key, string value, int expirationInSeconds, CancellationToken cancellationToken);

        Task<byte[]?> GetAsync(string key, CancellationToken cancellationToken);
    }
}
