using Blog.Models.Base;

namespace Blog.Repositories.GenericRepository;
public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    //Get all data
    Task<List<TEntity>> GetAll();
    IQueryable<TEntity> GetAllAsQueryable();

    //Create

    Guid Create(TEntity entity);
    Task<Guid> CreateAsync(TEntity entity);

    void CreateRange(IEnumerable<TEntity> entities);

    Task CreateRangeAsync(IEnumerable<TEntity> entities);

    //Update

    void Update(TEntity entity);    
    void UpdateRange(IEnumerable<TEntity> entities);

    //Delete

    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);  

    //Find

    TEntity FindById (object id);
    Task<TEntity> FindByIdAsync (object id);

    //Save
    bool Save();
    Task<bool> SaveAsync();
    
}
