using SIENN.BusinessInterfaces;
using SIENN.BusinessInterfaces.Contracts;
using SIENN.DbAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SIENN.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(ProductDTO entity)
        {
            _productRepository.Add(entity);
        }

        public ProductDTO Get(int id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return _productRepository.GetAll();
        }

        public ProductDTO GetDetailed(int id)
        {
            return _productRepository.GetDetailed(id);
        }

        public IEnumerable<ProductDTO> GetAvailable(int pageNo, int itemsCount)
        {
            return Search(new ProductSearchCriteria
            {
                PageNumber = pageNo,
                ItemsCount = itemsCount,
                IsAvailable = true
            });
        }

        public IEnumerable<ProductDTO> Search(ProductSearchCriteria criteria)
        {
            return _productRepository.Search(criteria ?? ProductSearchCriteria.Empty);
        }

        public void Remove(int id)
        {
            var entity = _productRepository.GetDetailed(id);
            _productRepository.Remove(entity);
        }

        public void Update(ProductDTO entity)
        {
            _productRepository.Update(entity);
        }
    }
}
