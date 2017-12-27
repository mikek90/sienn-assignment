using SIENN.BusinessInterfaces;
using SIENN.BusinessInterfaces.Contracts;
using SIENN.DbAccess.Repositories;
using System;
using System.Collections.Generic;
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

        public void Remove(ProductDTO entity)
        {
            _productRepository.Remove(entity);
        }

        public void Update(ProductDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
