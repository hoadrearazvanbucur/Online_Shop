using Online_Shop.Exceptions;
using Online_Shop.Model;
using Online_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Services
{
    public class ProductServices
    {
        public ProductRepository productRepository;

        public ProductServices(string dataBase)
        {
            this.productRepository = new ProductRepository(dataBase);
        }

        public List<Product> lista()
        {
            return productRepository.getAll();
        }

        public void create(Product product)
        {
            if (!this.exist(product.Categorie, product.Name, product.Description, product.Price, product.Stock))
            {
                this.productRepository.add(product);
            }
            else
            {
                throw new ProductException("Acest produs exista");
            }
        }
        public void deleteById(int id)
        {
            if (this.existId(id))
            {
                this.productRepository.deleteById(id);
            }
            else
            {
                throw new ProductException("Acest produs nu exista");
            }
        }
        public void delete(Product product)
        {
            if (this.exist(product.Categorie, product.Name, product.Description, product.Price, product.Stock))
            {
                this.productRepository.delete(product);
            }
            else
            {
                throw new ProductException("Acest produs nu exista");
            }
        }

        public void updateCategorie(Product product, string newCategorie)
        {
            if (this.exist(product.Categorie, product.Name, product.Description, product.Price, product.Stock))
            {
                this.productRepository.updateCategorie(product, newCategorie);
            }
            else
            {
                throw new ProductException("Acest produs nu exista");
            }
        }
        public void updateName(Product product, string newName)
        {
            if (this.exist(product.Categorie, product.Name, product.Description, product.Price, product.Stock))
            {
                this.productRepository.updateName(product, newName);
            }
            else
            {
                throw new ProductException("Acest produs nu exista");
            }
        }
        public void updateDescription(Product product, string newDescription)
        {
            if (this.exist(product.Categorie, product.Name, product.Description, product.Price, product.Stock))
            {
                this.productRepository.updateDescription(product, newDescription);
            }
            else
            {
                throw new ProductException("Acest produs nu exista");
            }
        }
        public void updateDate(Product product, DateTime date)
        {
            if (this.exist(product.Categorie, product.Name, product.Description, product.Price, product.Stock))
            {
                this.productRepository.updateDate(product, date);
            }
            else
            {
                throw new ProductException("Acest produs nu exista");
            }
        }
        public void updateImage(Product product, Byte[] newImage)
        {
            if (this.exist(product.Categorie, product.Name, product.Description, product.Price, product.Stock))
            {
                this.productRepository.updateImage(product, newImage);
            }
            else
            {
                throw new ProductException("Acest produs nu exista");
            }
        }
        public void updatePrice(Product product, double newPrice)
        {
            if (this.exist(product.Categorie, product.Name, product.Description, product.Price, product.Stock))
            {
                this.productRepository.updatePrice(product, newPrice);
            }
            else
            {
                throw new ProductException("Acest produs nu exista");
            }
        }
        public void updateStock(Product product, int newStock)
        {
            if (this.exist(product.Categorie, product.Name, product.Description, product.Price, product.Stock))
            {
                this.productRepository.updateStock(product, newStock);
            }
            else
            {
                throw new ProductException("Acest produs nu exista");
            }
        }

        public bool exist(string categorie, string name, string description, double price, int stock)
        {
            foreach (Product product in this.lista())
                if (product.Categorie == categorie && product.Name == name && product.Description == description && product.Price == price && product.Stock == stock)
                    return true;
            return false;
        }
        public bool existId(int id)
        {
            foreach (Product product in this.lista())
                if (product.Id == id)
                    return true;
            return false;
        }
    }
}
