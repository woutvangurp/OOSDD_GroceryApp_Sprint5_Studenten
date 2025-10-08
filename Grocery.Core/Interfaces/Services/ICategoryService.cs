using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.Core.Interfaces.Services {

    public interface ICategoryService {
        public void Create(Category category);

        public Category Get(int id);

        public ReadOnlyCollection<Category> GetAll();

        public Category Update(Category category);

        public void Delete(int id);
    }
}