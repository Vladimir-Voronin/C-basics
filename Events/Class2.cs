using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    static class StartSimulation
    {
        public static void Start()
        {
            ProductEventArgs e1 = new ProductEventArgs("")
        }
    }

    sealed class Basket
    {
        public event EventHandler<ProductEventArgs> NewProduct;

        public void OnNewProduct(ProductEventArgs e)
        {
            NewProduct(this, e);
        }
    }

    sealed class ProductEventArgs : EventArgs
    {
        private readonly string name;
        private readonly decimal price;
        public string Name { get { return name; } }
        public decimal Price { get { return price; } }

        ProductEventArgs(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
