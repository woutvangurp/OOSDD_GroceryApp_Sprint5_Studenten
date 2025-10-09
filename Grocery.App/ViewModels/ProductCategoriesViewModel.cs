using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels {
    [QueryProperty(nameof(CategoryId), "CategoryId")]
    public partial class ProductCategoriesViewModel : ObservableObject {
        private readonly IProductCategoryService _productCategoriesService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        [ObservableProperty] private int categoryId;
        [ObservableProperty] private string categoryName;
        [ObservableProperty] private ObservableCollection<Product> products = new();

        public ProductCategoriesViewModel(
                IProductCategoryService productCategoriesService,
                IProductService productService,
                ICategoryService categoryService) 
        {
            _productCategoriesService = productCategoriesService;
            _productService = productService;
            _categoryService = categoryService;
        }

        partial void OnCategoryIdChanged(int value) {
            LoadCategoryDetails();
            LoadProductsForCategory();
        }

        private void LoadCategoryDetails() {
            try {
                Category? category = _categoryService.Get(CategoryId);
                CategoryName = category?.Name ?? $"Categorie {CategoryId}";
            } catch (KeyNotFoundException) {
                CategoryName = "Onbekende categorie";
            }
        }

        private void LoadProductsForCategory() {
            List<Product> productList = _productCategoriesService.GetProductsByCategoryId(CategoryId);
            if (productList.Count <= 0)
                return;
            Products = new ObservableCollection<Product>(productList);
        }
    }
}
