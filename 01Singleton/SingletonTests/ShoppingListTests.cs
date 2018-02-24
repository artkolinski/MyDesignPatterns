﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;

namespace SingletonTests
{
    [TestClass]
    public class ShoppingListTests
    {
        [TestMethod]
        public void CompareShoppingListInstances()
        {
            var shoppingListInstance1 = ShoppingList.ShoppingListInstance;
            var shoppingListInstance2 = ShoppingList.ShoppingListInstance;

            Assert.AreEqual(shoppingListInstance1, shoppingListInstance2);
            Assert.AreSame(shoppingListInstance1, shoppingListInstance2);
            shoppingListInstance1.DeleteInstance();
        }

        [TestMethod]
        public void TestAvailableMethods()
        {
            var shoppingListInstance1 = ShoppingList.ShoppingListInstance;
            var shoppingListInstance2 = ShoppingList.ShoppingListInstance;

            shoppingListInstance1.AddProduct(new Product("PC", 8000));
            var productList = shoppingListInstance2.GetProductList();

            Assert.AreEqual(1, productList.Count);
            Assert.AreEqual(productList, shoppingListInstance1.GetProductList());         
            shoppingListInstance1.DeleteInstance();
        }

        [TestMethod]
        public void ThreadSafety()
        {
            var shoppingListInstance1 = ShoppingList.ShoppingListInstance;
            var shoppingListInstance2 = ShoppingList.ShoppingListInstance;
            var task1 = new Task(() => shoppingListInstance1.AddProduct(new Product("PC", 4000)));
            var task2 = new Task(() => shoppingListInstance2.AddProduct(new Product("DVD", 500)));

            task1.Start();
            task2.Start();
            task1.Wait();
            task2.Wait();

            Assert.AreEqual(2, shoppingListInstance1.GetProductList().Count);
            Assert.AreEqual(shoppingListInstance1, shoppingListInstance2);
            Assert.AreSame(shoppingListInstance1, shoppingListInstance2);
            Assert.IsTrue(shoppingListInstance1.Equals(shoppingListInstance2));
            shoppingListInstance1.DeleteInstance();
        }
    }
}
