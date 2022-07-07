using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CartManagerTests
    {
        private CartItem _cartItem;
        private CartManager _cartManager;

        [TestInitialize]
        public void TestInitialize()
        {
            _cartManager = new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product
                {
                    ProductId = 6,
                    ProductName = "Telefon",
                    UnitPrice = 6000
                },
                Quantity = 1
            };
    
            _cartManager.Add(_cartItem);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _cartManager.Clear();
        }
                   
        [TestMethod]
        public void Sepete_urun_eklenebilmelidir()
        {
            //Arrange
            const int beklenen = 1;

            //Act
            var toplamElemanSayisi = _cartManager.TotalItems;

            //Assert
            Assert.AreEqual(beklenen, toplamElemanSayisi);
        }

        [TestMethod]
        public void Sepette_olan_urun_cikarilabilmelidir()
        {
            //Arrange          
            var sepetteOlanElemanSayisi = _cartManager.TotalItems;

            //Act
            _cartManager.Remove(6);
            var sepetteKalanElemanSayisi = _cartManager.TotalItems;

            //Assert
            Assert.AreEqual(sepetteOlanElemanSayisi - 1, sepetteKalanElemanSayisi);
        }

        [TestMethod]
        public void Sepet_temizlenebilmelidir()
        {         
            //Act
            _cartManager.Clear();

            //Assert
            Assert.AreEqual(0, _cartManager.TotalQuantity);
            Assert.AreEqual(0, _cartManager.TotalItems);
        }
    }
}
