using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Services;

namespace Grocery.App.ViewModels {
    public class CategoriesViewModel {
        private readonly ICategoryService _categoryService;
        public ObservableCollection<Category> Categories { get; set; }

        public CategoriesViewModel(ICategoryService categoryService) {
            _categoryService = categoryService;
            Categories = new ObservableCollection<Category>();
            foreach (Category c in _categoryService.GetAll()) Categories.Add(c);
        }
    }
}
