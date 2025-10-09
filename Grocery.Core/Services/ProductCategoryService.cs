using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services {
    public class ProductCategoryService : IProductCategoryService {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IProductRepository productRepository) {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public List<Product> GetProductsByCategoryId(int categoryId) {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAll().Where(pc => pc.CategoryId == categoryId).ToList();

            return productCategories.Select(pc => _productRepository.Get(pc.ProductId)).OfType<Product>().ToList();
        }

        public void Create(ProductCategory productCategory) =>
            _productCategoryRepository.Create(productCategory);
        
        public ProductCategory? Get(int productId, int categoryId) =>
            _productCategoryRepository.Get(productId, categoryId);
        
        public List<ProductCategory> GetAll() => _productCategoryRepository.GetAll();
        
        public void Update(ProductCategory productCategory) =>
            _productCategoryRepository.Update(productCategory);
        
        public void Delete(int productId, int categoryId) =>
            _productCategoryRepository.Delete(productId, categoryId);
        
    }
}
