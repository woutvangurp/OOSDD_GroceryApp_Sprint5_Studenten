using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.Core.Services {
    public class CategoryService : ICategoryService {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }
        
        public void Create(Category category) {
            _categoryRepository.Create(category);
        }

        public Category Get(int id) {
            return _categoryRepository.Get(id);
        }
        public ReadOnlyCollection<Category> GetAll() {
            return _categoryRepository.GetAll();
        }
        public Category Update(Category category) {
            return _categoryRepository.Update(category);
        }
        public void Delete(int id) {
            _categoryRepository.Delete(id);
        }
    }
}
