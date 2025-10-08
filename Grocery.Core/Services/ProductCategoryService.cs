using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services {
    public class ProductCategoryService : IProductCategoryService {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        public ProductCategoryService(IProductCategoryService productCategoryService, IProductService productService) {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        public List<Product> GetProductsByCategoryId(int categoryId) {
            List<ProductCategory> productCategories = _productCategoryService.GetAll().Where(pc => pc.CategoryId == categoryId).ToList();

            return productCategories.Select(pc => _productService.Get(pc.ProductId)).OfType<Product>().ToList();
        }

        public void Create(ProductCategory productCategory) =>
            _productCategoryService.Create(productCategory);
        
        public ProductCategory? Get(int productId, int categoryId) => 
            _productCategoryService.Get(productId, categoryId);
        
        public List<ProductCategory> GetAll() => _productCategoryService.GetAll();
        
        public void Update(ProductCategory productCategory) =>
            _productCategoryService.Update(productCategory);
        
        public void Delete(int productId, int categoryId) =>
            _productCategoryService.Delete(productId, categoryId);
        
    }
}
