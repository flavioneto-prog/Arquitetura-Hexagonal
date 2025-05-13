namespace Domain.Ports
{
    public interface ICacheService
    {
        Task<byte[]?> GetByKeyAsync(string key, CancellationToken cancellationToken);

        Task AddNewAsync(string key, string value, int expirationInSeconds, CancellationToken cancellationToken = default);
    }
}
