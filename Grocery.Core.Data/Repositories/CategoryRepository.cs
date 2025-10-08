using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private readonly List<Category> categoryList;

        public CategoryRepository() {
            categoryList = new List<Category> {
                new Category(1, "zuivel"),
                new Category(2, "brood beleg"),
                new Category(3, "vlees"),
                new Category(4, "ontbijt"),
                new Category(5, "avond eten")
            };
        }
        public void Create(Category category) {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            if (categoryList.Any(c => c.Id == category.Id))
                throw new ArgumentException("A category with the same ID already exists");

            categoryList.Add(category);
        }

        public Category Get(int id) {
            if (id <= 0)
                throw new ArgumentException("ID must be a positive integer greater than zero");

            Category category = categoryList.FirstOrDefault(c => c.Id == id) 
                                ?? throw new KeyNotFoundException();

            return category ?? 
                   throw new KeyNotFoundException($"Category with ID {id} not found");
        }

        public ReadOnlyCollection<Category> GetAll() => categoryList.AsReadOnly();

        public Category Update(Category category) {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Category cannot be null");

            Category existingCategory = Get(category.Id);
            existingCategory.Name = category.Name;
            return existingCategory;
        }

        public void Delete(int id) {
            if (id <= 0)
                throw new ArgumentException("ID must be a positive integer greater than zero");
            Category category = Get(id);
            categoryList.Remove(category);
        }
    }
}
