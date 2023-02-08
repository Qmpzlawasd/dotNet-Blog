using Blog.Data;
using Blog.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected BlogContext _context;
    protected readonly DbSet<TEntity> _table;

    public GenericRepository(BlogContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    //Get all
    public async IAsyncEnumerable<TEntity> GetAll()
    {
        foreach (var row in await _table.AsNoTracking().ToListAsync())
        {
            yield return row;
        }
    }

    public IQueryable<TEntity> GetAllAsQueryable()
    {
        return _table.AsNoTracking();
    }
    
    public async Task<Guid> CreateAsync(TEntity entity)
    {
        await _table.AddAsync(entity);
        return entity.Id;
    }

    public void CreateRange(IEnumerable<TEntity> entities)
    {
        _table.AddRange(entities);
    }

    public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        await _table.AddRangeAsync(entities);
    }

    //Update
    public void Update(TEntity entity)
    {
        _table.Update(entity);
    }


    public void UpdateRange(IEnumerable<TEntity> entites)
    {
        _table.UpdateRange(entites);
    }

    //Delete
    public void Delete(TEntity entity)
    {
        entity.DateDeleted = DateTime.UtcNow;
        Save();
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _table.RemoveRange(entities);
    }

    //Find 
    public TEntity FindById(object id)
    {
        return _table.Find(id);

        //return _table.FirstOrDefault(x => x.Id.Equals(id));
    }

    public async Task<TEntity> FindByIdAsync(object id)
    {
        return await _table.FindAsync(id);
    }

    //Save
    public bool Save()
    {
        return _context.SaveChanges() > 0;
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}