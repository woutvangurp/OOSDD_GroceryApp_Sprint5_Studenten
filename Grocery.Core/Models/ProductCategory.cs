using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models {
    public class ProductCategory() {
        public int Id { get; set; }

        [ObservableProperty]
        public int ProductId;

        [ObservableProperty]
        public int CategoryId;

        public ProductCategory(int id, int productId, int categoryId) : this() {
            Id = id;
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}