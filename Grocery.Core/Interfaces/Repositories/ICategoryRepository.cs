using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Interfaces.Repositories {
    public interface ICategoryRepository {
        public void Create(Category category);

        public Category Get(int id);

        public ReadOnlyCollection<Category> GetAll();

        public Category Update(Category category);

        public void Delete(int id);
    }
}
