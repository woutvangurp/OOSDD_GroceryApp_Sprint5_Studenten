using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models {
    public class Category(int id, string name) {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;

        public Category() : this(0, string.Empty) { }
    }
}
