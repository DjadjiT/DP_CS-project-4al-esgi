using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Product
    {
        public Product(int id, string name, ProductSize size, string price)
        {
            this.ID = id;
            this.Name = name;
            this.Size = size;
            this.Price = price;
        }
        
        public int ID { get; }

        public string Name { get; }

        public ProductSize Size { get; }

        public string Price { get; }

    }

     public class ProductBuilder
    {
        private int _ID;
        private string _Name;
        private ProductSize _Size;
        private string _Price;

        public ProductBuilder WithId(int id)
        {
            _ID = id;
            return this;
        }

        public ProductBuilder WithName(string Name)
        {
            _Name = Name;
            return this;
        }

        public ProductBuilder WithSize(ProductSize size)
        {
            _Size = size;
            return this;
        }

        public ProductBuilder WithPrice(string price)
        {
            _Price = price;
            return this;
        }

        public Product Build()
        {
            return new Product(_ID, _Name, _Size, _Price);
        }
    }
}
