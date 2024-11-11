//using System.Linq.Expressions;
//using Microsoft.EntityFrameworkCore;
//using SystemManagementFactory.DB;
//using SystemManagementFactory.Domain.Entities;
//
//namespace SystemManagementFactory.Repositories.BaseRepository;
//
//public class GenericRepository<T>(AppCommandDbContext commandDb, AppQueryDbContext queryDb) : IGenericRepository<T> where T : BaseEntity
//{
//    public async Task AddAsync(T value)
//    {
//        await commandDb.Set<T>().AddAsync(value);
//        await commandDb.SaveChangesAsync();
//    }
//
//    public async Task AddRangeAsync(IEnumerable<T> values)
//    {
//        await commandDb.Set<T>().AddRangeAsync(values);
//        await commandDb.SaveChangesAsync();
//    }
//
//    public async Task UpdateAsync(T value)
//    {
//        commandDb.Set<T>().Update(value);
//        commandDb.SaveChangesAsync();
//    }
//
//    public async Task UpdateRangeAsync(IEnumerable<T> values)
//    {
//        commandDb.Set<T>().UpdateRange(values);
//        commandDb.SaveChangesAsync();
//    }
//
//    public async Task DeleteAsync(T value)
//    {
//        commandDb.Set<T>().Remove(value);
//        commandDb.SaveChangesAsync();
//    }
//
//    public async Task DeleteAsync(IEnumerable<T> values)
//    {
//        commandDb.Set<T>().RemoveRange(values);
//        commandDb.SaveChangesAsync();
//    }
//
//    public async Task<T?> GetByIdAsync(int id)
//    {
//        return await queryDb.Set<T>().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
//    }
//
//    public async Task<IEnumerable<T>> GetAllAsync()
//    {
//        return await queryDb.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
//    }
//
//    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
//    {
//        return await queryDb.Set<T>().Where(x => !x.IsDeleted).Where(expression).ToListAsync();
//    }
//}