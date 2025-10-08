using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grocery.Core.Data.Repositories {
    public class ProductCategoryRepository : IProductCategoryRepository {
        private readonly List<ProductCategory> productCategories;

        public ProductCategoryRepository() {
            productCategories = [
                new ProductCategory(1, 1, 1),
                new ProductCategory(2, 2, 1),
                new ProductCategory(3, 3, 2),
                new ProductCategory(4, 4, 4)
            ];
        }

        public void Create(ProductCategory productCategory) {
            if (productCategory == null)
                throw new ArgumentNullException(nameof(productCategory), "ProductCategory cannot be null");

            productCategories.Add(productCategory);
        }

        public ProductCategory? Get(int productId, int categoryId) {
            return productCategories.FirstOrDefault(pc => pc.ProductId == productId && pc.CategoryId == categoryId);
        }

        public List<ProductCategory> GetAll() => new List<ProductCategory>(productCategories);

        public void Update(ProductCategory productCategory) {
            if (productCategory == null)
                throw new ArgumentNullException(nameof(productCategory), "ProductCategory cannot be null");

            ProductCategory? existingProductCategory = Get(productCategory.ProductId, productCategory.CategoryId);
            if (existingProductCategory != null) {
                existingProductCategory.ProductId = productCategory.ProductId;
                existingProductCategory.CategoryId = productCategory.CategoryId;
            }
        }

        public void Delete(int productId, int categoryId) {
            ProductCategory? productCategory = Get(productId, categoryId);
            if (productCategory != null) {
                productCategories.Remove(productCategory);
            }
        }
    }
}
