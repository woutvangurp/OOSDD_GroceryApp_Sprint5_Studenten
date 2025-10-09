using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Models;
using Grocery.Core.Interfaces.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Grocery.App.Views;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : ObservableObject
    {
        private readonly ICategoryService _categoryService;
        
        [ObservableProperty]
        private ObservableCollection<Category> categories = new();
        
        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            LoadCategories();
        }
        
        private void LoadCategories()
        {
            var allCategories = _categoryService.GetAll();
            Categories = new ObservableCollection<Category>(allCategories);
        }
        
        [RelayCommand]
        private async Task NavigateToCategory(Category? category)
        {
            if (category == null) return;
            
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "CategoryId", category.Id }
            };
            
            await Shell.Current.GoToAsync($"{nameof(ProductCategoriesView)}", true, parameters);
        }
    }
}
