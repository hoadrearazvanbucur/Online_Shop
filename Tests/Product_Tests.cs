using Online_Shop.Services;
using Online_Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Online_Shop.Exceptions;

namespace Tests
{
    public class Product_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private ProductServices productServices;
        public Product_Tests(ITestOutputHelper output)
        {
            this.outputHelper = output;
            this.productServices = new ProductServices("Test");
            this.productServices.productRepository.deleteAll();

        }
        [Fact]
        public void adaugare_stergere()
        {
            Byte[] image = new Byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xfc, 0x7f, 0x8f, 0x8f, 0xc7, 0xc7, 0xf0, 0xf8, 0xff, 0xfc, 0x7c };
            DateTime date = DateTime.Now;
            this.productServices.create(new Product("categorie1", "nume1", "descriere1", date, image, 12.4, 34));
            Assert.Equal("Acest produs exista", Assert.Throws<ProductException>(() => productServices.create(new Product("categorie1", "nume1", "descriere1", date, image, 12.4, 34))).Message);
            this.productServices.delete(new Product("categorie1", "nume1", "descriere1", date, image, 12.4, 34));
            Assert.Equal("Acest produs nu exista", Assert.Throws<ProductException>(() => productServices.delete(new Product("categorie1", "nume1", "descriere1", date, image, 12.4, 34))).Message);
        }

        [Fact]
        public void update()
        {
            Byte[] image = new Byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xfc, 0x7f, 0x8f, 0x8f, 0xc7, 0xc7, 0xf0, 0xf8, 0xff, 0xfc, 0x7c };
            DateTime date = DateTime.Now;
            this.productServices.create(new Product("categorie1", "nume1", "descriere1", date, image, 12.4, 34));
            Assert.Equal("Acest produs exista", Assert.Throws<ProductException>(() => productServices.create(new Product("categorie1", "nume1", "descriere1", date, image, 12.4, 34))).Message);

            this.productServices.updateCategorie(new Product("categorie1", "nume1", "descriere1", date, image, 12.4, 34), "categorie2");
            Assert.Equal("Acest produs nu exista", Assert.Throws<ProductException>(() => productServices.updateCategorie(new Product("categorie1", "nume1", "descriere1", date, image, 12.4, 34), "categorie2")).Message);
            this.productServices.updateName(new Product("categorie2", "nume1", "descriere1", date, image, 12.4, 34), "nume2");
            Assert.Equal("Acest produs nu exista", Assert.Throws<ProductException>(() => productServices.updateName(new Product("categorie2", "nume1", "descriere1", date, image, 12.4, 34), "nume2")).Message);
            this.productServices.updateDescription(new Product("categorie2", "nume2", "descriere1", date, image, 12.4, 34), "descriere2");
            Assert.Equal("Acest produs nu exista", Assert.Throws<ProductException>(() => productServices.updateDescription(new Product("categorie2", "nume2", "descriere1", date, image, 12.4, 34), "descriere2")).Message);
            this.productServices.updatePrice(new Product("categorie2", "nume2", "descriere2", date, image, 12.4, 34), 1);
            Assert.Equal("Acest produs nu exista", Assert.Throws<ProductException>(() => productServices.updatePrice(new Product("categorie2", "nume2", "descriere2", date, image, 12.4, 34), 1)).Message);
            this.productServices.updateStock(new Product("categorie2", "nume2", "descriere2", date, image, 1, 34), 2);
            Assert.Equal("Acest produs nu exista", Assert.Throws<ProductException>(() => productServices.updateStock(new Product("categorie2", "nume2", "descriere2", date, image, 1, 34), 2)).Message);
            DateTime date1 = new DateTime(2003, 06, 07);
            Byte[] image1 = new Byte[] { 0xff, 0xff, 0xff, 0xff, 0xff };
            this.productServices.updateDate(new Product("categorie2", "nume2", "descriere2", date, image, 1, 2), date1);
            this.productServices.updateImage(new Product("categorie2", "nume2", "descriere2", date, image, 1, 2), image1);
            this.productServices.delete(new Product("categorie2", "nume2", "descriere2", date1, image1, 1, 2));
            Assert.Equal("Acest produs nu exista", Assert.Throws<ProductException>(() => productServices.delete(new Product("categorie2", "nume2", "descriere2", date1, image1, 1, 2))).Message);
        }

    }
}
