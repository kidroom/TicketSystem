using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// 取得第一筆符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        T Get(Guid id);

        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        IList<T> List();

        IList<T> List(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 新增一筆資料。
        /// </summary>
        /// <param name="entity">要新增到的Entity</param>
        void Insert(T entity);

        /// <summary>
        /// 更新一筆資料的內容。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        void Update(T entity);

        /// <summary>
        /// 刪除一筆資料內容。
        /// </summary>
        /// <param name="entity">要被刪除的Entity。</param>
        void Delete(T entity);

        Task<T> GetAsync(Guid id);

        Task InsertAsync(T entity);

        Task<IList<T>> ListAsync();

        Task<IList<T>> ListAsync(Expression<Func<T, bool>> expression);




        /// <summary>
        /// 儲存異動。
        /// </summary>
        void SaveChanges();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MsDbContext _context;

        public GenericRepository(MsDbContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Get(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IList<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public IList<T> List(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IList<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _context.Commit();
            }
            finally
            {
                _context.TransactionDispose();
            }
        }

        public void Rollback()
        {
            _context.Rollback();
            _context.TransactionDispose();
        }
    }
}
