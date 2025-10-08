using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models {
    public class ProductCategory : ObservableObject {
        public int Id { get; set; }

        private int productId;

        private int categoryId;

        public int ProductId {
            get => productId;
            set => SetProperty(ref productId, value);
        }

        public int CategoryId {
            get => categoryId;
            set => SetProperty(ref categoryId, value);
        }

        public ProductCategory(int id, int productId, int categoryId) {
            Id = id;
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}