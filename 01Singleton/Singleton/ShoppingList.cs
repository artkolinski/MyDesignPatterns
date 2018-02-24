using System.Collections.Generic;

namespace Singleton
{
    public class ShoppingList
    {
        private static ShoppingList _shoppingListInstance;
        private readonly List<Product> _productList;
        private static readonly object MyLock = new object();
        public static ShoppingList ShoppingListInstance
        {
            get
            {
                if (_shoppingListInstance == null)
                {
                    lock (MyLock)
                    {
                        if (_shoppingListInstance == null)
                        {
                            _shoppingListInstance = new ShoppingList();
                        }

                    }
                }
                return _shoppingListInstance;
            }
        }
        private ShoppingList()
        {
            _productList = new List<Product>();
        }
        public List<Product> GetProductList()
        {
            lock (MyLock)
            {
                return _productList;
            }
        }
        public void AddProduct(Product product)
        {
            lock (MyLock)
            {
                _productList.Add(product);
            }
        }
        public void DeleteInstance()
        {
                _shoppingListInstance = null;
        }
    }
}
