using BAYA.Core.Repositories;
using BAYA.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Service.Services
{
    public class GenericService<T> : IGenericRepository<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;


        public GenericService(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(T entity)
        {
            return _genericRepository.AddAsync(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _genericRepository.GetByIdAsync(id);
        }

        public IQueryable<T> GetListByFilter(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.GetListByFilter(expression);
        }

        public void Remove(T entity)
        {
            _genericRepository.Remove(entity);
        }

        public void Update(T entity)
        {
            _genericRepository.Update(entity);            
        }
    }
}
