using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services {

    public interface IProductCategoryService {
        public void Create(ProductCategory productCategory);

        public ProductCategory? Get(int productId, int categoryId);

        public List<ProductCategory> GetAll();

        public void Update(ProductCategory productCategory);

        public void Delete(int productId, int categoryId);
    }
}