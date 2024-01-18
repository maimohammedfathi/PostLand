namespace PostLandApplication.Interfaces
{
    public interface IGRepository<T> where T : class
    {
        #region Methods Get
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        #endregion

        #region Methods Add
        Task<T> AddAsync(T entity);
        #endregion

        #region Methods Update
        Task UpdateAsync(T entity);
        #endregion

        #region Methods Delete
        Task DeleteAsync(T entity);
        #endregion
    }
}
