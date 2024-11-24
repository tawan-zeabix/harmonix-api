namespace UpdatePolicyService.Repositories.Interfaces;
public interface IBaseRepository<T>
{
    public Task<T?> GetByIdAsync(int id);
    public Task<T> InsertAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
}

