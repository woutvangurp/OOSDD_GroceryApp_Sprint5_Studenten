using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;
        public DateOnly ShelfLife { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, int stock) : this(id, name, stock, 0, default) { }

        public Product(int id, string name, int stock, DateOnly shelfLife) : base(id, name)
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Price = 0;
        }
        public Product(int id, string name, int stock, decimal price, DateOnly shelfLife) : this(id, name, stock, shelfLife)
        {
            Price = price;
        }

        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad";
        }
    }
}
