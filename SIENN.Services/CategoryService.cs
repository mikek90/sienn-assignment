using SIENN.BusinessInterfaces;
using SIENN.BusinessInterfaces.Contracts;
using SIENN.DbAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(CategoryDTO entity)
        {
            _categoryRepository.Add(entity);
        }

        public CategoryDTO Get(int id)
        {
            return _categoryRepository.Get(id);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public void Remove(int id)
        {
            var entity = _categoryRepository.GetDetailed(id);
            _categoryRepository.Remove(entity);
        }

        public void Update(CategoryDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
