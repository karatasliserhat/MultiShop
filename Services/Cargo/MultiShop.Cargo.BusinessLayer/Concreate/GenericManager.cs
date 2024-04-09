using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using System.Linq.Expressions;

namespace MultiShop.Cargo.BusinessLayer.Concreate
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task CreateAsync(T entity)
        {
           await _genericDal.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
           await _genericDal.DeleteAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task<T> GetFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _genericDal.GetFilterAsync(filter);
        }

        public async Task UpdateAsync(T entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
    }
}
