using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Interfaces.Repositories {
    public interface IProductCategoryRepository {
        public void Create(ProductCategory productCategory);

        public ProductCategory? Get(int productId, int categoryId);

        public List<ProductCategory> GetAll();

        public void Update(ProductCategory productCategory);

        public void Delete(int productId, int categoryId);
    }
}
